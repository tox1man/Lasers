using UnityEditor;
using static Parameters;
using static ModuleGUILayout;
using UnityEngine;

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
                if (Application.isPlaying) { DisplayPosition(myScript); }
                DisplayInputColors(myScript);
                DisplayTargetColor(myScript);
                break;
            case ModuleType.Emitter:
                if (Application.isPlaying) { DisplayPosition(myScript); }
                DisplayLaserColors(myScript);
                DisplayLaserDirection(myScript);
                break;
            case ModuleType.Reflector:
                if (Application.isPlaying) { DisplayPosition(myScript); }
                break;
            case ModuleType.Disperser:
                if (Application.isPlaying) { DisplayPosition(myScript); }
                DisplayLaserColors(myScript);
                break;
            default:
                break;
        }
    }
}