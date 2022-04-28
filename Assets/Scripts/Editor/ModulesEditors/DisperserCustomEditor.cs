using UnityEditor;
using static ModuleGUILayout;
using UnityEngine;

[CustomEditor(typeof(DisperserView))]
[CanEditMultipleObjects]
public class DisperserCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DisperserView disperser = (DisperserView)target;
        if (Application.isPlaying) { DisplayPosition(disperser); }
        DisplayLaserColors(disperser);
    }
}