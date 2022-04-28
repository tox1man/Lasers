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
            int ColorIndex =  Array.IndexOf(LaserColors.ColorsList, myScript.Lasers[i].LaserColor);
            BeginHorizontal();
                myScript.ToggleLaserFromEditor(myScript.Lasers[i], GUILayout.Toggle(myScript.Lasers[i].Enabled, $"Laser {i}"));
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
            foreach (Color color in myScript.InputColors)
            {
                GUI.enabled = false;
                BeginHorizontal();
                LabelField($"Input color #{myScript.InputColors.IndexOf(color)}");
                ColorField(color);
                EndHorizontal();
                GUI.enabled = true;
            }
        EndVertical();
    }
    public static void DisplayTargetColor(ModuleObjectView myScript)
    {
        LabelField("Target Color");
        BeginVertical();
            int index = Array.IndexOf(LaserColors.ColorsList, myScript.TargetColor);
            int ColorIndex = index;
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
        int colorIndex = Array.IndexOf(LaserColors.ColorsList, myScript.TargetColor);
        myScript.TargetColor = LaserColors.ColorsList[Popup(colorIndex, GetColorNamesArray())];
        GUI.enabled = false;
        ColorField(LaserColors.ColorsList[colorIndex].Color);
        GUI.enabled = true;
    }
    public static void DisplayPosition(ModuleObjectView myScript)
    {
        BeginHorizontal();
            Vector2Int position = Vector2IntField("", myScript.Tile);
            Space();
        EndHorizontal();
        myScript.Move(position);
    }
    public static void DisplayPortalPairPosition(ModuleObjectView myScript)
    {
        BeginHorizontal();
        try
        {
            Vector2Int position2 = Vector2IntField("", myScript.PortalPair.TileTwo);
            myScript.PortalPair.MovePortalTwo(position2);
        }
        catch { EndHorizontal(); return; }
            Space();
        EndHorizontal();
    }
}
