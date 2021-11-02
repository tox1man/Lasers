using UnityEditor;
using UnityEngine;
using static Parameters;
using static UnityEditor.EditorGUILayout;

[CustomEditor(typeof(ModuleObjectView))]
[CanEditMultipleObjects]
public class ModuleCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var myScript = target as ModuleObjectView;
        switch (myScript.Type)
        {
            case ModuleType.Absorber:
                myScript.Laser.enabled = false;
                Foldout(true, "Input colors");
                    BeginVertical();
                    for (int i = 0; i < myScript.InputColors.Count; i++)
                    {
                        GUI.enabled = false;
                        BeginHorizontal();
                        LabelField($"Input color #{i}");
                        ColorField(myScript.InputColors[i]);
                        EndHorizontal();
                        GUI.enabled = true;
                    }
                    EndVertical();
                break;
            case ModuleType.Emitter:
                myScript.Laser = (LineRenderer)ObjectField("Laser", myScript.Laser, typeof(LineRenderer), true);
                myScript.Laser.enabled = true;

                // Color choosing dropmenu.
                LabelField("Laser Color");
                BeginHorizontal();
                    myScript.indexColor = Popup(Mathf.Clamp(myScript.indexColor, 0, LASER_COLORS.Length - 1), LASER_COLORS_NAMES);
                    GUI.enabled = false;
                    ColorField(LASER_COLORS[myScript.indexColor]);
                    GUI.enabled = true;
                EndHorizontal();
                    
                // Laser direction choosing dropmenu.
                switch (EnumPopup("Laser Direction", myScript.LaserDirection))
                {
                    case Direction.North:
                        myScript.LaserDirection = Direction.North;
                        break;
                    case Direction.East:
                        myScript.LaserDirection = Direction.East;
                        break;
                    case Direction.South:
                        myScript.LaserDirection = Direction.South;
                        break;
                    case Direction.West:
                        myScript.LaserDirection = Direction.West;
                        break;
                    default:
                        break;
                }
                break;
            case ModuleType.Reflector:
                myScript.Laser.enabled = false;
                break;
            case ModuleType.Disperser:
                myScript.Laser.enabled = false;
                break;
            default:
                break;
        }
    }
}