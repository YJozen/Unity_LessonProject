using System.Collections.Generic;
using UnityEngine;

public class BoundsOctree {
    public BoundsOctreeNode root;

    public BoundsOctree(Bounds bounds) {
        root = new BoundsOctreeNode(bounds);
    }

    public void Insert(Collider collider) {
        root.Insert(collider);
    }

    public List<Collider> Query(Bounds queryBounds) {
        return root.Query(queryBounds);
    }

        public List<Collider> QueryFrustum(Plane[] planes) {
        List<Collider> results = new List<Collider>();
        root.QueryFrustumRecursive(planes, results);
        return results;
    }
}
