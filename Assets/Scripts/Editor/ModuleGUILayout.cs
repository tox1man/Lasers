using System;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static Parameters;

public static class ModuleGUILayout
{
    public static void DisplayLaserColors(ModuleObjectView myScript)
    {
        for (int i = 0; i < myScript.Lasers.Count; i++)
        {
            int ColorIndex = Array.IndexOf(LaserColors.ColorsList, myScript.Lasers[i].LaserColor);
            BeginHorizontal();
                myScript.ToggleLaserFromEditor(myScript.Lasers[i], GUILayout.Toggle(myScript.Lasers[i].ToggleFromEditor, $"Laser {i}"));
                myScript.Lasers[i].LaserColor = LaserColors.ColorsList[Popup(ColorIndex, GetColorNamesArray())];
                GUI.enabled = false;
                ColorField(LaserColors.ColorsList[ColorIndex].Color);
                GUI.enabled = true;
            EndHorizontal();
        }
    }
    public static void DisplayLaserDirection(ModuleObjectView myScript)
    {
        switch (EnumPopup(myScript.LaserDirection))
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
    }
    public static void DisplayInputColors(ModuleObjectView myScript)
    {
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
    }
    public static void DisplayTargetColor(ModuleObjectView myScript)
    {
        LabelField("Target Color");
        BeginVertical();
            int ColorIndex = Array.IndexOf(LaserColors.ColorsList, myScript.TargetColor);
            BeginHorizontal();
                myScript.TargetColor = LaserColors.ColorsList[Popup(ColorIndex, GetColorNamesArray())];
                GUI.enabled = false;
                ColorField(LaserColors.ColorsList[ColorIndex].Color);
                GUI.enabled = true;
            EndHorizontal();
        EndVertical();
    }
    public static void DisplayAbsorberTargetColor(ModuleObjectView myScript)
    {
        int ColorIndex = Array.IndexOf(LaserColors.ColorsList, myScript.TargetColor);
        myScript.TargetColor = LaserColors.ColorsList[Popup(ColorIndex, GetColorNamesArray())];
        GUI.enabled = false;
        ColorField(LaserColors.ColorsList[ColorIndex].Color);
        GUI.enabled = true;
    }
}
