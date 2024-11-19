using UnityEngine;

namespace RaySample{
    public class RaycastLayerMaskExample3 : MonoBehaviour
    {
        public float rayDistance = 10f;
        public LayerMask layerMask; // 対象レイヤーを指定するためのレイヤーマスク

        void Update()
        {
            // レイを前方に発射
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
            {
                Debug.Log("Hit object: " + hit.collider.name);
                // 例: ヒットした点でエフェクトを表示する
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            else
            {
                // ヒットしなかった場合の処理
                Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
            }
        }
    }
}