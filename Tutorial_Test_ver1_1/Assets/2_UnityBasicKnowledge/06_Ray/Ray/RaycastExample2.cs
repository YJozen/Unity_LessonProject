using UnityEngine;

namespace RaySample{
    public class RaycastAllExample2 : MonoBehaviour
    {
        public float rayDistance = 10f;

        void Update()
        {
            // レイを前方に発射
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, rayDistance);

            foreach (RaycastHit hit in hits)
            {
                Debug.Log("Hit object: " + hit.collider.name);
                // 例: ヒットした点でエフェクトを表示する
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
        }
    }
}