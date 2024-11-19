#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomEditorSample
{

    public class SampleURL : EditorWindow
    {
        [MenuItem("OpenURL/FirstProjectsSample")]
        static void Open() {
            GetWindow<SampleURL>("OpenURL");
        }

        void OnGUI() {
            EditorGUILayout.LabelField($"現在のサイズ : {position.size}");

            minSize = new Vector2(200f, 50f);
            maxSize = new Vector2(300f, 100f);

            //using var scope = new EditorGUILayout.VerticalScope();

            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Open Sample Projects")) {
                //任意のURLを開く
                Application.OpenURL("https://drive.google.com/drive/folders/1HB7OoyzdHM3_PNg-6Q7Ln2pf44dN0e1m");
            }

            GUILayout.FlexibleSpace();

        }


    }

}

#endif