using UnityEditor;
using UnityEngine;

public class CustomEditorWindow : EditorWindow
{
    [MenuItem("Window/Custom Tool")]
    public static void ShowWindow()
    {
        GetWindow<CustomEditorWindow>("Custom Tool");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Press me"))
        {
            Debug.Log("Button Pressed!");
        }
    }
}
