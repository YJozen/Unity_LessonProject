using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 追従対象のTransform
    public float smoothSpeed = 0.125f;  // スムーズな追従のための補間速度
    public Vector3 offset;  // 追従時のオフセット

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);  // ターゲットを常に注視
    }
}