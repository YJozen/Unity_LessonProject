using UnityEngine;
using UnityEditor;

public class PrefabEditorUtility : EditorWindow
{
    private GameObject prefab; // 配置するPrefab
    private GameObject parentObject; // 子供として追加する親オブジェクト
    private Vector3 spawnPosition = Vector3.zero; // 配置位置
    private int spawnCount = 1; // 生成する個数

    [MenuItem("Tools/Prefab Spawner")]
    public static void ShowWindow()
    {
        GetWindow<PrefabEditorUtility>("Prefab Spawner");
    }

    private void OnGUI()
    {
        GUILayout.Label("Prefab Spawner Settings", EditorStyles.boldLabel);

        // Prefabの選択フィールド
        prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);

        // 親オブジェクトの選択フィールド
        parentObject = (GameObject)EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true);

        // 生成位置と生成個数の入力フィールド
        spawnPosition = EditorGUILayout.Vector3Field("Spawn Position", spawnPosition);
        spawnCount = EditorGUILayout.IntField("Spawn Count", spawnCount);

        // 生成ボタン
        if (GUILayout.Button("Spawn Prefabs"))
        {
            SpawnPrefabs();
        }
    }

    private void SpawnPrefabs()
    {
        // Prefabが未設定の場合は警告を表示
        if (prefab == null)
        {
            Debug.LogWarning("Prefab is not set.");
            return;
        }

        // 親オブジェクトが未設定の場合は警告を表示
        if (parentObject == null)
        {
            Debug.LogWarning("Parent Object is not set.");
            return;
        }

        // Undo機能を追加（Ctrl+Zで戻れるようにする）
        Undo.RecordObject(parentObject, "Spawn Prefabs");

        // 指定数のPrefabを生成
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.transform.SetParent(parentObject.transform);

            // 各Prefabの位置を設定
            instance.transform.localPosition = spawnPosition + new Vector3(i * 1.5f, 0, 0); // 水平方向に配置
            Undo.RegisterCreatedObjectUndo(instance, "Spawn Prefab");
        }
    }
}
