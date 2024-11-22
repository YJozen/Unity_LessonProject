namespace PaintableTest {

using UnityEngine;

public class PaintCameraController : MonoBehaviour
{
    public Camera captureCamera; // 塗りを判定するためのカメラ
    public Paintable paintable; // 塗り処理のスクリプト
    private RenderTexture renderTexture;

    void Start()
    {
        // レンダーテクスチャを設定
        renderTexture = new RenderTexture(256, 256, 24);
        captureCamera.targetTexture = renderTexture;

        // 塗りレイヤーをキャプチャするカメラの設定
        captureCamera.cullingMask = 1 << LayerMask.NameToLayer("Paintable");
    }

    // 塗られた割合を計算するメソッド
    public float CalculatePaintedPercentage()
    {
        // レンダーテクスチャの内容を取得
        Texture2D capturedTexture = new Texture2D(renderTexture.width, renderTexture.height);
        RenderTexture.active = renderTexture;
        capturedTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        capturedTexture.Apply();

        // 塗られた部分をカウント
        int paintedPixels = 0;
        int totalPixels = capturedTexture.width * capturedTexture.height;

        for (int x = 0; x < capturedTexture.width; x++)
        {
            for (int y = 0; y < capturedTexture.height; y++)
            {
                Color pixelColor = capturedTexture.GetPixel(x, y);
                if (pixelColor == paintable.paintColor)
                {
                    paintedPixels++;
                }
            }
        }

        // 塗られた割合を計算
        float paintedPercentage = (float)paintedPixels / totalPixels * 100f;
        return paintedPercentage;
    }
}


}