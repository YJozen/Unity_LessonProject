using UnityEngine;
using System.Collections.Generic;

public class CameraBasedOctreeManager : MonoBehaviour
{
    public Camera mainCamera;
    public BoundsOctree boundsOctree;
    public float octreeSize = 100f;
    public float visibilityRange = 50f;
    public LayerMask targetLayer;

    void Start()
    {
        // Octreeの初期化
        Bounds bounds = new Bounds(Vector3.zero, Vector3.one * octreeSize);
        boundsOctree = new BoundsOctree(bounds);

        // Octreeにシーンのオブジェクトを登録
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (var collider in colliders)
        {
            if ((targetLayer.value & (1 << collider.gameObject.layer)) != 0)
            {
                boundsOctree.Insert(collider);
            }
        }
    }

    void Update()
    {
        if (mainCamera == null || boundsOctree == null) return;

        // カメラの視錐台の平面を取得
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        // Octreeからカメラの視界内にあるオブジェクトを取得
        List<Collider> collidersInView = boundsOctree.QueryFrustum(planes);

        // 表示するオブジェクトを更新
        UpdateObjectVisibility(collidersInView);
    }

    private void UpdateObjectVisibility(List<Collider> collidersInView)
    {
        // 全オブジェクトの非表示処理
        Collider[] allColliders = FindObjectsOfType<Collider>();
        foreach (Collider collider in allColliders)
        {
            if ((targetLayer.value & (1 << collider.gameObject.layer)) != 0)
            {
                collider.gameObject.SetActive(false);
            }
        }

        // 視界内のオブジェクトのみ表示
        foreach (Collider collider in collidersInView)
        {
            collider.gameObject.SetActive(true);
        }
    }

    void OnDrawGizmos()
    {
        if (boundsOctree != null)
        {
            boundsOctree.root.DrawGizmos(Color.yellow);
        }

        if (mainCamera != null)
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = mainCamera.transform.localToWorldMatrix;
            Gizmos.DrawFrustum(Vector3.zero, mainCamera.fieldOfView, mainCamera.farClipPlane, mainCamera.nearClipPlane, mainCamera.aspect);
        }
    }
}
