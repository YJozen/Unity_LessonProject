using System.Collections.Generic;
using UnityEngine;

public class PointOctree {
    public PointOctreeNode root;

    public PointOctree(Bounds bounds) {
        root = new PointOctreeNode(bounds);
    }

    public void Insert(Vector3 point) {
        root.Insert(point);
    }

    public List<Vector3> Query(Bounds queryBounds) {
        return root.Query(queryBounds);
    }
}
