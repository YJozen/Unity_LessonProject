#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneEditorSampleComponent))]
public class SceneEditorSample : Editor
{
    private void OnSceneGUI()
    {
        Transform targetTransform = (target as MonoBehaviour).transform;
        
        // ラベルの表示
        Handles.Label(targetTransform.position + Vector3.up * 2f, "Move Up", 
            new GUIStyle() { normal = { textColor = Color.cyan } });

        // ボタンの表示と処理
        Handles.color = Color.red;
        if (Handles.Button(targetTransform.position + Vector3.up * 1.5f + Vector3.right * 0.5f, 
            Quaternion.identity, 0.5f, 0.5f, Handles.SphereHandleCap))
        {
            // 移動処理
            Undo.RecordObject(targetTransform, "Move Up");
            targetTransform.position += Vector3.up * 2f;
        }
    }
}


#endif