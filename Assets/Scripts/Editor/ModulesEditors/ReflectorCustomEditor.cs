using UnityEditor;
using static ModuleGUILayout;
using UnityEngine;

[CustomEditor(typeof(ReflectorView))]
[CanEditMultipleObjects]
public class ReflectorCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ReflectorView reflector = (ReflectorView)target;
        if (Application.isPlaying) { DisplayPosition(reflector); }
    }
}