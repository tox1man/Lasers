using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Parameters;

public class Laser
{
    public ModuleObjectView View { get; set; }
    public LaserColor LaserColor { get; set; }
    public Vector3 Direction { get; set; } 
    public LineRenderer Line { get; set; }
    public bool Enabled { get; set; }

    public Laser(ModuleObjectView view, LaserColor laserColor, Vector3 direction, LineRenderer line)
    {
        View = view;
        LaserColor = laserColor;
        Direction = direction;
        Line = line;
    }
    /// <summary>
    /// Shoots laser. If it hits object - interacts with it.
    /// </summary>
    /// <param name="direction">Original laser direction.</param>
    /// <param name="distance">Maximum laser distance.</param>
    /// <param name="points">Laser path points.</param>
    public void Shoot(Vector3 direction, float distance, List<Vector3> points = null)
    {
        RaycastHit hit;
        List<Vector3> laserPoints;

        // if points list exists AND is not empty
        if (points != null && points.Any()) 
        {
            laserPoints = points;
        }
        else
        {
            laserPoints = new List<Vector3>();
            laserPoints.Add(View.Transform.position);
        }

        Vector3 startPoint = laserPoints[laserPoints.Count - 1];
        if (laserPoints.Count < LASER_MAX_REFLECTIONS)
        {
            if (Physics.Raycast(new Ray(startPoint, direction), out hit, distance))
            {
                GameObjectView hitObjectView = hit.collider.gameObject.GetComponentInParent<GameObjectView>(); // try to optimize?
                if (hitObjectView != null)
                {
                    laserPoints.Add(hit.point);
                    switch (hitObjectView)
                    {
                        case ModuleObjectView module:
                            if (module == null) return;
                            switch (module.Type)
                            {
                                case ModuleType.Absorber: // absorb laser
                                    Absorb(module, LaserColor.Color);
                                    break;
                                case ModuleType.Emitter: // absorb laser
                                    Absorb();
                                    break;
                                case ModuleType.Reflector: // reflect laser around normal
                                    Reflect(direction, hit, distance, laserPoints);
                                    break;
                                case ModuleType.Disperser: // cast new lasers
                                    if (module == View) break;
                                    Disperse(module, hit, distance);
                                    break;
                                case ModuleType.Portal: // teleport laser on the other side of the portal
                                    Teleport(module, hit, direction, distance);
                                    break;
                                default:
                                    Debug.LogWarning($"Unknown module type. {this}.{nameof(Shoot)}");
                                    break;
                            }
                            break;
                        case TileObjectView tile:
                            Absorb();
                            break;
                        default:
                            Absorb();
                            break;
                    }
                }
            }
            else laserPoints.Add(direction.normalized * LASER_MAX_DIST + startPoint);
        }
        RenderLaser(laserPoints.ToArray());
    }
    /// <summary>
    /// Reflects laser off the surface.
    /// </summary>
    /// <param name="direction">Original laser direction.</param>
    /// <param name="hit">Hit object.</param>
    /// <param name="distance">Maximum laser distance.</param>
    /// <param name="laserPoints">Laser path points.</param>
    private void Reflect(Vector3 direction, RaycastHit hit, float distance, List<Vector3> laserPoints)
    {
        direction = Vector3.Reflect(direction, hit.normal);
        Shoot(direction, distance, laserPoints);
    }
    /// <summary>
    /// Disperses laser on the opposite side of the object. If laser is White - decomposes it in R,G,B.
    /// Otherwise preserve original color.
    /// </summary>
    /// <param name="other">View of object hit by laser.</param>
    /// <param name="hit">Hit object.</param>
    /// <param name="distance">Maximum laser lenght.</param>
    private void Disperse(ModuleObjectView other, RaycastHit hit, float distance) 
    {
        if (hit.collider.gameObject.transform.parent.name == "Faces" && !other.Lasers[1].Enabled) // SOME LASERS UPDATE FIRST THAN OTHERS
        {
            Vector3 forwardDirection = -hit.normal;
            Vector3 leftDirection = Quaternion.Euler(0f, -60, 0f) * forwardDirection;
            Vector3 rightDirection = Quaternion.Euler(0f, 60, 0f) * forwardDirection;

            if (LaserColor.Color == Color.white)
            {
                other.ToggleLaserFromEditor(other.Lasers[0], true);
                other.ToggleLaserFromEditor(other.Lasers[1], true);
                other.ToggleLaserFromEditor(other.Lasers[2], true);

                other.Lasers[0].LaserColor = LaserColors.Red;
                other.Lasers[1].LaserColor = LaserColors.Green;
                other.Lasers[2].LaserColor = LaserColors.Blue;

                other.Lasers[0].Shoot(leftDirection, distance);
                other.Lasers[1].Shoot(forwardDirection, distance);
                other.Lasers[2].Shoot(rightDirection, distance);
            }
            else
            {
                other.Lasers[1].LaserColor = LaserColor;
                other.ToggleLaserFromEditor(other.Lasers[1], true);
                other.Lasers[1].Shoot(forwardDirection, distance);
            }
        }
        else if (hit.collider.gameObject.transform.parent.name == "Edges")
        {
            Absorb();
        }
    }
    /// <summary>
    /// Absorbs laser without color change to the object. 
    /// Not implemented for now.
    /// </summary>
    private void Absorb()
    {
        // ABROBS LASER
    }
    /// <summary>
    /// Absorbs laser and change objects color to that of a lasers.
    /// </summary>
    /// <param name="other">View of object hit by laser.</param>
    /// <param name="color">Color to apply to object.</param>
    private void Absorb(ModuleObjectView other, Color color)
    {
        other.TryAddColor(color);
    }
    // MULTIPLE TELEPORTATION (?)
    /// <summary>
    /// Teleports laser to other side of portal.
    /// </summary>
    /// <param name="other"></param>
    /// <param name="hit"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    private void Teleport(ModuleObjectView other, RaycastHit hit, Vector3 direction, float distance)
    {
        // Incoming angle restrictions. 
        // Only allow angles that gives Dot product with laser direction greater than PORTAL_MIN_DOT
        bool isAngleAllowed = Mathf.Abs(Vector3.Dot(hit.transform.forward, direction.normalized)) > PORTAL_MIN_DOT;
        if (!isAngleAllowed) return;

        PortalView view = (PortalView)other;

        if (hit.transform == view.PortalPair.TransformOne)
        {
            List<Vector3> laserPoints2 = new List<Vector3>();
            laserPoints2.Add(view.PortalPair.TransformTwo.position);
            Vector3 newDir = Quaternion.FromToRotation(view.PortalPair.TransformOne.forward, -direction.normalized) * view.PortalPair.TransformTwo.forward;
            view.ToggleLaserFromEditor(view.Lasers[1], true);
            view.Lasers[1].LaserColor = LaserColor;
            view.Lasers[1].Shoot(newDir, distance, laserPoints2);
            return;
        }
        else
        {
            List<Vector3> laserPoints1 = new List<Vector3>();
            laserPoints1.Add(view.PortalPair.TransformOne.position);
            Vector3 newDir = Quaternion.FromToRotation(view.PortalPair.TransformTwo.forward, direction.normalized) * view.PortalPair.TransformOne.forward;
            view.ToggleLaserFromEditor(view.Lasers[0], true);
            view.Lasers[0].LaserColor = LaserColor;
            view.Lasers[0].Shoot(newDir, distance, laserPoints1);
        }
    }
    /// <summary>
    /// Traces laser path with LineRenderer component.
    /// </summary>
    /// <param name="points">Laser path points.</param>
    private void RenderLaser(Vector3[] points)
    {
        if (Line != null)
        {
            Line.startWidth = Mathf.Min(View.Transform.localScale.x / 6, View.Transform.localScale.y / 6, View.Transform.localScale.z / 6);
            Line.positionCount = points.Length;
            Line.SetPositions(points);
            Line.endWidth = Line.startWidth;
            Line.material.color = LaserColor.Color;
        }
    }
}