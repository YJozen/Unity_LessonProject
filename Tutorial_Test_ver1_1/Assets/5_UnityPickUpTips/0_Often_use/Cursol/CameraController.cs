using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 300f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // カーソルを非表示にしてロックする
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // マウスの移動量を取得
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // カメラの回転を計算
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // カメラの上下制限

        // カメラの回転を適用
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // ESCキーを押したらカーソルロックを解除
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;  
        }
    }
}