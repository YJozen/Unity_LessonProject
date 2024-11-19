using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;  // カメラが周回する対象
    public float distance = 5.0f;  // ターゲットとの距離
    public float xSpeed = 120.0f;  // 水平方向の回転速度
    public float ySpeed = 120.0f;  // 垂直方向の回転速度
    public float yMinLimit = -20f; // 垂直方向の最小角度
    public float yMaxLimit = 80f;  // 垂直方向の最大角度

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        // カメラの初期角度を設定
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        // マウスの入力を取得
        if (target)// && Input.GetMouseButton(1))  // 右クリックで回転操作
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            // 垂直方向の角度を制限
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            // カメラの位置と回転を設定
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
