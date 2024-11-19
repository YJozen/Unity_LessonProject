// using UnityEngine;

// namespace RaySample{
//     public class MultipleRaycastsExample : MonoBehaviour
//     {
//         public float rayDistance = 10f;
//         public float fieldOfView = 45f; // 視野の角度
//         public int numberOfRays = 10;    // 発射するレイの数

//         void Update()
//         {
//             float angleStep = fieldOfView / numberOfRays;
//             float currentAngle = -fieldOfView / 2;

//             for (int i = 0; i < numberOfRays; i++)
//             {
//                 // レイを発射する方向を計算
//                 Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * transform.forward;
//                 Ray ray = new Ray(transform.position, direction);
//                 RaycastHit hit;

//                 if (Physics.Raycast(ray, out hit, rayDistance))
//                 {
//                     Debug.Log("Hit object: " + hit.collider.name);
//                     Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
//                 }

//                 currentAngle += angleStep;
//             }
//         }
//     }
// }