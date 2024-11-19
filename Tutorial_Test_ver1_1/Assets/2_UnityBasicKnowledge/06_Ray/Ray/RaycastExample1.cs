using UnityEngine;

namespace RaySample{
    public class RaycastExample1 : MonoBehaviour
    {
        public float rayDistance = 10f;

        void Update()
        {
            // レイを前方に発射
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
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

