using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // インスタンス化するPrefab
    public int objectsPerArea = 10;  // 各エリアに生成するオブジェクトの数
    public float spawnAreaSize = 100f; // スポーンエリアのサイズ

    private void Start()
    {
        // スポーンエリアの初期化
        Bounds spawnBounds = new Bounds(Vector3.zero, Vector3.one * spawnAreaSize);

        // 各エリアにPrefabをインスタンス化
        SpawnPrefabsInArea(spawnBounds);
    }

    private void SpawnPrefabsInArea(Bounds bounds)
    {
        // エリアを8つのサブエリアに分割
        Vector3 size = bounds.size / 2;
        Bounds[] subAreas = new Bounds[8];

        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int z = 0; z < 2; z++)
                {
                    Vector3 newCenter = bounds.center + new Vector3(
                        (x - 0.5f) * size.x,
                        (y - 0.5f) * size.y,
                        (z - 0.5f) * size.z
                    );

                    Bounds subArea = new Bounds(newCenter, size);
                    subAreas[x * 4 + y * 2 + z] = subArea;

                    // 各サブエリアにPrefabをインスタンス化
                    for (int i = 0; i < objectsPerArea; i++)
                    {
                        Vector3 randomPosition = GetRandomPositionInBounds(subArea);
                        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
                    }
                }
            }
        }
    }

    private Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
