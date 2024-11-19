using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(URL_Jump))]
public class InspectorButtonSample : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Sample Projects URL"))
        {
            URL_Jump url_jump = (URL_Jump)target;
            url_jump.OpenURL();
        }
    }
}
