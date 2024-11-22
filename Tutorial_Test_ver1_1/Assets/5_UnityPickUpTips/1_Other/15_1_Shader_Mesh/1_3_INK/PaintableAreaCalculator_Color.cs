using UnityEngine;

public class PaintableAreaCalculator_Color : MonoBehaviour
{
    public Paintable paintable; // 対象のPaintableオブジェクト

    private Texture2D tempTexture; // 一時的にピクセルデータを保持するテクスチャ

    /// <summary>
    /// 色ごとの塗られた割合を計算するメソッド
    /// </summary>
    /// <returns>塗られた割合 (0.0f～1.0f)</returns>
    public void CalculatePaintedAreaByColor()
    {
        if (paintable == null)
        {
            Debug.LogError("Paintable instance is not assigned!");
            return;
        }

        // Paintable のマスクテクスチャを取得
        RenderTexture maskTexture = paintable.getMask();
        if (maskTexture == null)
        {
            Debug.LogError("Mask RenderTexture is null!");
            return;
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

        // 色ごとのカウント
        int paintedRedPixels = 0;
        int paintedGreenPixels = 0;
        int paintedBluePixels = 0;
        int paintedAlphaPixels = 0;

        foreach (Color pixel in pixels)
        {
            // 塗られているとみなす条件 (アルファ値が閾値を超える)
            if (pixel.a > 0.1f) 
            {
                // 色ごとにカウント
                if (pixel.r > 0.1f) paintedRedPixels++;
                if (pixel.g > 0.1f) paintedGreenPixels++;
                if (pixel.b > 0.1f) paintedBluePixels++;
                paintedAlphaPixels++;
            }
        }

        // 色ごとの割合を表示
        Debug.Log($"Red Painted Area: {(float)paintedRedPixels / totalPixels * 100:F2}%");
        Debug.Log($"Green Painted Area: {(float)paintedGreenPixels / totalPixels * 100:F2}%");
        Debug.Log($"Blue Painted Area: {(float)paintedBluePixels / totalPixels * 100:F2}%");
        Debug.Log($"Alpha Painted Area: {(float)paintedAlphaPixels / totalPixels * 100:F2}%");
    }

    // デバッグ用
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Spaceキーを押すと色ごとの割合を表示
        {
            CalculatePaintedAreaByColor();
        }
    }
}
