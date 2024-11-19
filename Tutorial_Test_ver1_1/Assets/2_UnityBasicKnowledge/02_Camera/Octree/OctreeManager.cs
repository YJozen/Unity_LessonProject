using UnityEngine;
using System.Collections.Generic;

public class OctreeManager : MonoBehaviour {
    public BoundsOctree boundsOctree;
    public PointOctree pointOctree;
    public Transform player;
    public float visibilityRange = 20.0f;

    // 全てのColliderを保持するリスト
    private List<Collider> allColliders;

    void Start() {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(100, 100, 100));
        boundsOctree = new BoundsOctree(bounds);
        pointOctree = new PointOctree(bounds);

        // シーン内の全てのColliderを取得し、Octreeに追加
        allColliders = new List<Collider>(FindObjectsOfType<Collider>());
        foreach (var collider in allColliders) {
            boundsOctree.Insert(collider);
        }

        // ランダムにポイントを追加
        for (int i = 0; i < 100; i++) {
            Vector3 point = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            pointOctree.Insert(point);
        }
    }

    void OnDrawGizmos() {
        if (boundsOctree != null) {
            boundsOctree.root.DrawGizmos(Color.red);
        }

        if (pointOctree != null) {
            pointOctree.root.DrawGizmos(Color.blue);
        }

        if (player != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(player.position, visibilityRange);
        }
    }

    void Update() {
        if (player == null) return;

        // Playerの周りの描画範囲
        Bounds viewBounds = new Bounds(player.position, Vector3.one * visibilityRange * 2);

        // 範囲内のColliderを取得
        List<Collider> collidersInRange = boundsOctree.Query(viewBounds);

        // 範囲内のオブジェクトを表示
        foreach (Collider collider in collidersInRange) {
            collider.gameObject.SetActive(true);
        }

        // 範囲外のオブジェクトを非表示
        foreach (Collider collider in allColliders) {
            if (!collidersInRange.Contains(collider)) {
                collider.gameObject.SetActive(false);
            }
        }
    }
}
