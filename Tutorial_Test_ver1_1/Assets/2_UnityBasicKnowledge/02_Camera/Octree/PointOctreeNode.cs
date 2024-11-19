using System.Collections.Generic;
using UnityEngine;

public class PointOctreeNode {
    public Bounds bounds; // ノードの範囲
    public List<Vector3> points; // ノード内のポイント
    public PointOctreeNode[] children; // 子ノードへの参照
    private const int MAX_POINTS = 10; // ノードあたりの最大ポイント数

    public PointOctreeNode(Bounds bounds) {
        this.bounds = bounds;
        this.points = new List<Vector3>();
        this.children = null; // 初期は子ノードなし
    }

    public void Insert(Vector3 point) {
        // ポイントをこのノードに挿入
        if (!bounds.Contains(point)) return; // 範囲外の場合は無視

        points.Add(point);

        // 子ノードが満杯の場合は分割
        if (points.Count > MAX_POINTS && children == null) {
            Subdivide(); // 子ノードを生成
        }

        // 子ノードにポイントを挿入
        if (children != null) {
            foreach (var child in children) {
                child.Insert(point);
            }
        }
    }

    private void Subdivide() {
        // ノードを8つの子ノードに分割
        Vector3 size = bounds.size / 2;
        children = new PointOctreeNode[8];

        for (int x = 0; x < 2; x++) {
            for (int y = 0; y < 2; y++) {
                for (int z = 0; z < 2; z++) {
                    Vector3 newCenter = bounds.center + new Vector3(
                        (x - 0.5f) * size.x,
                        (y - 0.5f) * size.y,
                        (z - 0.5f) * size.z
                    );

                    Bounds childBounds = new Bounds(newCenter, size);
                    children[x * 4 + y * 2 + z] = new PointOctreeNode(childBounds);
                }
            }
        }
    }

    public List<Vector3> Query(Bounds queryBounds) {
        List<Vector3> results = new List<Vector3>();

        // このノード内のポイントを追加
        foreach (var point in points) {
            if (queryBounds.Contains(point)) {
                results.Add(point);
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
