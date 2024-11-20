using UnityEngine;

public class PaintableAreaCalculator : MonoBehaviour
{
    public Paintable paintable; // 対象のPaintableオブジェクト

    private Texture2D tempTexture; // 一時的にピクセルデータを保持するテクスチャ

    /// <summary>
    /// 塗られた割合を計算するメソッド
    /// </summary>
    /// <returns>塗られた割合 (0.0f～1.0f)</returns>
    public float CalculatePaintedArea()
    {
        if (paintable == null)
        {
            Debug.LogError("Paintable instance is not assigned!");
            return 0f;
        }

        // Paintable のマスクテクスチャを取得
        RenderTexture maskTexture = paintable.getMask();
        if (maskTexture == null)
        {
            Debug.LogError("Mask RenderTexture is null!");
            return 0f;
        }

        // RenderTexture を Texture2D にコピー
        RenderTexture.active = maskTexture;
        if (tempTexture == null || tempTexture.width != maskTexture.width || tempTexture.height != maskTexture.height)
        {
            tempTexture = new Texture2D(maskTexture.width, maskTexture.height, TextureFormat.RGBA32, false);
        }
        tempTexture.ReadPixels(new Rect(0, 0, maskTexture.width, maskTexture.height), 0, 0);
        tempTexture.Apply();
        RenderTexture.active = null;

        // ピクセルデータを解析
        Color[] pixels = tempTexture.GetPixels();
        int totalPixels = pixels.Length;
        int paintedPixels = 0;

        foreach (Color pixel in pixels)
        {
            // 塗られているとみなす条件 (例: アルファ値が閾値を超える)
            if (pixel.a > 0.1f) // アルファ値が0.1以上なら塗られているとみなす
            {
                paintedPixels++;
            }
        }

        // 塗られた割合を返す
        return (float)paintedPixels / totalPixels;
    }

    // デバッグ用
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Spaceキーを押すと割合を表示
        {
            float paintedRatio = CalculatePaintedArea();
            Debug.Log($"Painted Area: {paintedRatio * 100:F2}%");
        }
    }
}
