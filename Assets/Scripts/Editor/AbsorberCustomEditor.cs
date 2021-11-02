using System;
using UnityEditor;

[CustomEditor(typeof(AbsorberView))]
[CanEditMultipleObjects]
public class AbsorberCustomEditor : ModuleCustomEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
