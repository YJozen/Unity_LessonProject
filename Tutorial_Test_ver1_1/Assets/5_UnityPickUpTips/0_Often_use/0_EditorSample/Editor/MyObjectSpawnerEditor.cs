#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyObjectSpawner))]
public class MyObjectSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // 通常のインスペクター要素を描画
        DrawDefaultInspector();

        // スポーナーオブジェクトを参照
        MyObjectSpawner spawner = (MyObjectSpawner)target;

        // スポーンボタンを追加
        if (GUILayout.Button("Spawn Object"))
        {
            spawner.SpawnObject();
        }

        // スポーン位置をランダムに生成するボタン
        if (GUILayout.Button("Randomize Position"))
        {
            spawner.spawnPosition = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(0f, 5f),
                Random.Range(-10f, 10f)
            );
        }
    }
}
#endif
