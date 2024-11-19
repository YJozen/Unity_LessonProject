using UnityEditor;
using UnityEngine;

public class QuickAccessWindow : EditorWindow
{
    [MenuItem("Window/Quick Access")]
    public static void ShowWindow()
    {
        GetWindow<QuickAccessWindow>("Quick Access");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Select Player"))
        {
            var player = GameObject.Find("Player");
            Selection.activeGameObject = player;
        }
    }
}