using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float closeDelay = 3.0f; // �����܂�܂ł̑ҋ@����
    private Coroutine closeDoorCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter");
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("triggerExit");
        if (other.CompareTag("Player"))
        {
            // �v���C���[���g���K�[�͈͂𗣂ꂽ�Ƃ��ɔ���߂�R���[�`�����J�n
            if (closeDoorCoroutine != null)
            {
                StopCoroutine(closeDoorCoroutine);
            }

            closeDoorCoroutine = StartCoroutine(CloseDoorAfterDelay());
        }
    }

    private void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetBool("isOpen", false);
    }
}
