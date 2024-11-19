using UnityEngine;

public class ParticleCollisionDetector : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        // エフェクトがGameObjectに当たった際の処理
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("VFX hit the target!");
            // 追加の処理をここに記述
        }
    }
}
