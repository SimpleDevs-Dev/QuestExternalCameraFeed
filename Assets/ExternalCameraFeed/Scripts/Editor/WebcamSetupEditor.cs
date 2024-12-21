using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WebcamSetup))]
public class WebcamSetupEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if (!Application.isPlaying) return;
        WebcamSetup current = (WebcamSetup)target;

        if (current.devices != null && current.devices.Length > 0) {
            for(int i = 0; i < current.devices.Length; i++) {
                if(GUILayout.Button($"Select {current.devices[i].name}")) {
                    current.SelectDevice(i);
                }
            }
        }

        EditorGUILayout.Space();

        if(GUILayout.Button("Next Device")) {
            current.NextDevice();
        }
    }
}
