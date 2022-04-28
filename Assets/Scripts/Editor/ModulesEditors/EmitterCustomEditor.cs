using UnityEditor;
using static ModuleGUILayout;
using UnityEngine;

[CustomEditor(typeof(EmitterView))]
[CanEditMultipleObjects]
public class EmitterCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EmitterView emitter = (EmitterView)target;
        if (Application.isPlaying) { DisplayPosition(emitter); }
        DisplayLaserColors(emitter);
        DisplayLaserDirection(emitter);
    }
}