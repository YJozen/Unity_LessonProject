using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MyScript myScript = (MyScript)target;
        if (GUILayout.Button("Execute Action"))
        {
            myScript.PerformAction(); // 実行する関数
        }
    }
}