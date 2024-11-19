using UnityEngine;
using System.Collections.Generic;

public class BoundsOctreeNode {
    public Bounds bounds; // ノードの範囲
    public List<Collider> colliders; // ノード内のコライダー
    public BoundsOctreeNode[] children; // 子ノードへの参照
    private const int MAX_COLLIDERS = 4; // ノードあたりの最大コライダー数

    public BoundsOctreeNode(Bounds bounds) {
        this.bounds = bounds;
        this.colliders = new List<Collider>();
        this.children = null; // 初期は子ノードなし
    }

    public void Insert(Collider collider) {
        // コライダーをこのノードに挿入
        if (!bounds.Intersects(collider.bounds)) return; // 範囲外の場合は無視

        colliders.Add(collider);

        // 子ノードが満杯の場合は分割
        if (colliders.Count > MAX_COLLIDERS && children == null) {
            Subdivide(); // 子ノードを生成
        }

        // 子ノードにコライダーを挿入
        if (children != null) {
            foreach (var child in children) {
                child.Insert(collider);
            }
        }
    }

    private void Subdivide() {
        // ノードを8つの子ノードに分割
        Vector3 size = bounds.size / 2;
        children = new BoundsOctreeNode[8];

        for (int x = 0; x < 2; x++) {
            for (int y = 0; y < 2; y++) {
                for (int z = 0; z < 2; z++) {
                    Vector3 newCenter = bounds.center + new Vector3(
                        (x - 0.5f) * size.x,
                        (y - 0.5f) * size.y,
                        (z - 0.5f) * size.z
                    );

                    Bounds childBounds = new Bounds(newCenter, size);
                    children[x * 4 + y * 2 + z] = new BoundsOctreeNode(childBounds);
                }
            }
        }
    }

    public List<Collider> Query(Bounds queryBounds) {
        List<Collider> results = new List<Collider>();

        // このノード内のコライダーを追加
        foreach (var collider in colliders) {
            if (queryBounds.Intersects(collider.bounds)) {
                results.Add(collider);
            }
        }

        // 子ノードに対してクエリを実行
        if (children != null) {
            foreach (var child in children) {
                if (child.bounds.Intersects(queryBounds)) {
                    results.AddRange(child.Query(queryBounds));
                }
            }
        }

        return results;
    }


    public void QueryFrustumRecursive(Plane[] planes, List<Collider> results) {
        if (!GeometryUtility.TestPlanesAABB(planes, bounds)) {
            return;
        }

        foreach (var collider in colliders) {
            if (GeometryUtility.TestPlanesAABB(planes, collider.bounds)) {
                results.Add(collider);
            }
        }

        if (children != null) {
            foreach (var child in children) {
                child.QueryFrustumRecursive(planes, results);
            }
        }
    }

    public void DrawGizmos(Color color) {
        Gizmos.color = color;
        Gizmos.DrawWireCube(bounds.center, bounds.size);

        if (children != null) {
            foreach (var child in children) {
                child.DrawGizmos(color);
            }
        }
    }
}
