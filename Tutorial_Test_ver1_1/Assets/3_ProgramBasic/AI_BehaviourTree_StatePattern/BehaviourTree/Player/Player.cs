using UnityEngine;

namespace GameNamespace
{
    public class Player : MonoBehaviour
    {
        public Vector3 Position => transform.position;

        public float Health { get; private set; } = 100f;

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Player has died.");
            // Implement player death logic
        }
    }
}
