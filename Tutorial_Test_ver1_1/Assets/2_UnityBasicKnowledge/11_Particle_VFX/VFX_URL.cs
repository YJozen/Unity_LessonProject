#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomEditorSample
{

    public class VFX_URL : EditorWindow
    {
        [MenuItem("OpenURL/VFX_URL")]
        static void Open() {
            GetWindow<VFX_URL>("OpenURL");
        }

        void OnGUI() {
            EditorGUILayout.LabelField($"現在のサイズ : {position.size}");

            minSize = new Vector2(200f, 50f);
            maxSize = new Vector2(300f, 100f);

            //using var scope = new EditorGUILayout.VerticalScope();

            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Open WebSite VFX_Samples")) {
                //任意のURLを開く
                Application.OpenURL("https://www.youtube.com/c/gabrielaguiarprod");
            }

            GUILayout.FlexibleSpace();

        }
    }

}

#endif