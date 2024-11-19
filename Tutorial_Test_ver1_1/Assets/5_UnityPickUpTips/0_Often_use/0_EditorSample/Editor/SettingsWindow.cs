using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    private string mySetting;

    [MenuItem("Window/Settings")]
    public static void ShowWindow()
    {
        GetWindow<SettingsWindow>("Settings");
    }

    private void OnGUI()
    {
        mySetting = EditorGUILayout.TextField("My Setting", mySetting);

        if (GUILayout.Button("Save Setting"))
        {
            EditorPrefs.SetString("mySetting", mySetting);
        }

        if (GUILayout.Button("Load Setting"))
        {
            mySetting = EditorPrefs.GetString("mySetting", "Default Value");
        }

        if (GUILayout.Button("Reset"))
        {
            EditorPrefs.DeleteKey("mySetting");
        }
    }
}