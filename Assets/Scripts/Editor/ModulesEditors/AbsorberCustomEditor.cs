using UnityEditor;
using static ModuleGUILayout;
using UnityEngine;

[CustomEditor(typeof(AbsorberView))]
[CanEditMultipleObjects]
public class AbsorberCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AbsorberView absorber = (AbsorberView)target;
        if (Application.isPlaying) { DisplayPosition(absorber); }
        DisplayInputColors(absorber);
        DisplayTargetColor(absorber);
    }
}