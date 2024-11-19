using UnityEngine;

public class MouseSpeedTracker : MonoBehaviour
{
    private Vector3 _lastMousePosition;
    private float _mouseSpeed;

    void Start()
    {
        // 最初のフレームのマウス位置を記録
        _lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // 現在のマウス位置を取得
        Vector3 currentMousePosition = Input.mousePosition;

        // マウスの速さを計算 (単位: ピクセル/秒)
        _mouseSpeed = (currentMousePosition - _lastMousePosition).magnitude / Time.deltaTime;

        // マウス位置の更新
        _lastMousePosition = currentMousePosition;

        // マウスの速さを出力
        Debug.Log("Mouse Speed: " + _mouseSpeed + " pixels/second");
    }
}


