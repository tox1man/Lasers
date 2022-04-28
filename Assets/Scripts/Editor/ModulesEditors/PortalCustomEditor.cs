using UnityEditor;
using static ModuleGUILayout;
using UnityEngine;

[CustomEditor(typeof(PortalView))]
[CanEditMultipleObjects]
public class PortalCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PortalView portal = (PortalView)target;
        if (Application.isPlaying) 
        { 
            DisplayPosition(portal); 
            DisplayPortalPairPosition(portal);
        }
        DisplayLaserColors(portal);
    }
}