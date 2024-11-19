using UnityEngine;

namespace GameNamespace.Enemy
{
    public class DetectionRange : MonoBehaviour
    {
        public float detectionRadius = 10f;

        public bool IsPlayerInDetectionRange(Transform player)
        {
            return Vector3.Distance(transform.position, player.position) <= detectionRadius;
        }
    }
}
