using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float closeDelay = 3.0f; // 扉が閉まるまでの待機時間
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
            // プレイヤーがトリガー範囲を離れたときに扉を閉めるコルーチンを開始
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
