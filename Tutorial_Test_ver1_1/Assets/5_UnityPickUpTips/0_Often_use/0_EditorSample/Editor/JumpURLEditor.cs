using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyScript))]
public class JumpURLEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        if (GUILayout.Button("Visit Unity_Lesson Page"))
        {
            Application.OpenURL("https://yjozen.github.io/Unity_Lesson/");
        }
    }
}