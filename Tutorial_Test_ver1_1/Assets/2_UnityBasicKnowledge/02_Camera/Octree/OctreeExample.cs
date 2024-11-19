using UnityEngine;
using System.Collections.Generic;

public class OctreeExample : MonoBehaviour {
    private BoundsOctree boundsOctree;
    private PointOctree pointOctree;

    void Start() {
        // Octreeの初期化
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(100, 100, 100));
        boundsOctree = new BoundsOctree(bounds);
        pointOctree = new PointOctree(bounds);
        
        // コライダーの挿入例
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (var collider in colliders) {
            boundsOctree.Insert(collider);
        }

        // ポイントの挿入例
        for (int i = 0; i < 100; i++) {
            Vector3 point = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            pointOctree.Insert(point);
        }

        // クエリ例
        Bounds queryBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(20, 20, 20));
        List<Collider> queriedColliders = boundsOctree.Query(queryBounds);
        List<Vector3> queriedPoints = pointOctree.Query(queryBounds);

        // 結果を表示
        Debug.Log("Queried Colliders: " + queriedColliders.Count);
        Debug.Log("Queried Points: " + queriedPoints.Count);
    }
}
