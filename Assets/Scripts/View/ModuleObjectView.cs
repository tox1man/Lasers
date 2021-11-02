using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Parameters;

public class ModuleObjectView : GameObjectView
{
    [Header("Module Object Parameters")]
    public ModuleType Type;

    public GameObject laserPrefab;
    [HideInInspector] public List<Color> InputColors = new List<Color>();
    [HideInInspector] public LineRenderer Laser;
    [HideInInspector] public Direction LaserDirection;
    [HideInInspector] public int indexColor = 0;

    public void ShootLaser(Vector3 direction, float distance, List<Vector3> points = null)
        {
            RaycastHit hit;
            List<Vector3> laserPoints;

            if (Type != ModuleType.Emitter)
            {
                //return;
            }

            if (points != null && points.Any()) // if points list exists AND is not empty
            {
                laserPoints = points;
            }
            else
            {
                laserPoints = new List<Vector3>();
                laserPoints.Add(Transform.position);
            }

            Vector3 startPoint = laserPoints[laserPoints.Count - 1];
            if(laserPoints.Count < LASER_MAX_REFLECTIONS)
            {
                if (Physics.Raycast(new Ray(startPoint, direction), out hit, distance))
                {
                    ModuleObjectView otherView = hit.collider.gameObject.GetComponentInParent<ModuleObjectView>();
                    if (otherView == null)
                    {
                        return;
                    }
                    laserPoints.Add(hit.point);

                    switch (otherView.Type)
                    {
                        case ModuleType.Absorber: // absorb laser
                            otherView.TryAddColor(LASER_COLORS[indexColor]);
                            break;
                        case ModuleType.Emitter: // absorb laser
                            //AbsorbLaser();
                            break;
                        case ModuleType.Reflector: // reflect laser around normal
                            direction = Vector3.Reflect(direction, hit.normal);
                            ShootLaser(direction, distance, laserPoints);
                            break;
                        case ModuleType.Disperser: // cast new lasers
                            Vector3 v = Quaternion.Euler(0f, -60, 0f) * direction;
                            Vector3 v1 = Quaternion.Euler(0f, 60, 0f) * direction;
                            if(hit.collider.gameObject.transform.parent.name == "Faces") 
                            {
                                Debug.DrawRay(otherView.Transform.position, direction * 10f, Color.yellow);
                                Debug.DrawRay(otherView.Transform.position, v * 10f, Color.yellow);
                                Debug.DrawRay(otherView.Transform.position, v1 * 10f, Color.yellow);
                                //List<Vector3> disperserLaserPoints = new List<Vector3>() { Transform.position };
                                //ShootLaser(direction, distance);
                                //ShootLaser(v, distance);
                                //ShootLaser(v1, distance);
                            }
                            else if(hit.collider.gameObject.transform.parent.name == "Edges")
                            {
                                //absorb
                            }
                            break;
                        default:
                            Debug.LogWarning($"Unknown module type. {this}.{nameof(ShootLaser)}");
                            break;
                    }
                }
                else
                {
                    laserPoints.Add(direction.normalized * 50f + startPoint);
                }
            }
            RenderLaser(laserPoints.ToArray());
        }

    private void RenderLaser(Vector3[] points)
    {
        if(Laser != null)
        {
            Laser.positionCount = points.Length;
            Laser.SetPositions(points);
            Laser.endWidth = Laser.startWidth / 2;
            Laser.material.color = LASER_COLORS[indexColor];
            Laser.enabled = true;
        }
    }

    public Quaternion GetQuaternionFromDir(Direction dir)
    {
        Quaternion result = Quaternion.identity;
        Vector3 resultVector = Vector3.zero;
        switch (dir)
        {
            case Direction.North:
                result = Quaternion.LookRotation(Vector3.forward);
                resultVector = Vector3.forward;
                break;
            case Direction.East:
                result = Quaternion.LookRotation(Vector3.right);
                resultVector = Vector3.right;
                break;
            case Direction.South:
                result = Quaternion.LookRotation(Vector3.back);
                resultVector = Vector3.back;
                break;
            case Direction.West:
                result = Quaternion.LookRotation(Vector3.left);
                resultVector = Vector3.left;
                break;
        }
        return result;
    }
    public Vector3 GetVectorFromDir(Direction dir)
    {
        Vector3 result = Vector3.zero;
        switch (dir)
        {
            case Direction.North:
                result = Vector3.forward;
                break;
            case Direction.East:
                result = Vector3.right;
                break;
            case Direction.South:
                result = Vector3.back;
                break;
            case Direction.West:
                result = Vector3.left;
                break;
        }
        return result;
    }
    private void TryAddColor(Color other)
    {
        if (!InputColors.Contains(other)) 
        { 
            InputColors.Add(other); 
        }
    }
    public Color MixColors(Color[] colors)
    {
        if (colors.Length == 0)
        {
            return Color.white;
        }

        InputColors = new List<Color>();
        float r = 0;
        float g = 0;
        float b = 0;
        int numberOfColors = colors.Length;

        foreach (Color color in colors)
        {
            r += color.r;
            g += color.g;
            b += color.b;
        }
        return new Color(r, g, b);
    }
    public void ApplyColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
