using UnityEditor;
using static Parameters;
using static ModuleGUILayout;

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
                DisplayInputColors(myScript);
                DisplayTargetColor(myScript);
                break;
            case ModuleType.Emitter:
                DisplayLaserColors(myScript);
                DisplayLaserDirection(myScript);
                break;
            case ModuleType.Reflector:
                break;
            case ModuleType.Disperser:
                DisplayLaserColors(myScript);
                break;
            default:
                break;
        }
    }
}