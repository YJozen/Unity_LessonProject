using UnityEngine;

public class ParticleCollisionDetector : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        // �G�t�F�N�g��GameObject�ɓ��������ۂ̏���
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("VFX hit the target!");
            // �ǉ��̏����������ɋL�q
        }
    }
}
