using UnityEngine;

public class MyObjectSpawner : MonoBehaviour
{
    public GameObject prefab; // スポーンするオブジェクトのPrefab
    public Vector3 spawnPosition; // スポーン位置

    // オブジェクトをスポーンするメソッド
    public void SpawnObject()
    {
        if (prefab != null)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefabが指定されていません！");
        }
    }
}
