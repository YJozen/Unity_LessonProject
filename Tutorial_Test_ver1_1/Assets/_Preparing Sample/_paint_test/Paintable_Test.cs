namespace PaintableTest {
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public Texture2D texture; // 塗料用のテクスチャ
    public Color paintColor = Color.red; // 塗料の色
    private bool isPainting = false;
    public int brushSize = 10; // ブラシのサイズ（塗る範囲）

    void Start()
    {
        // 塗料用テクスチャを初期化
        int textureWidth = 256; // テクスチャの幅
        int textureHeight = 256; // テクスチャの高さ
        texture = new Texture2D(textureWidth, textureHeight);

        // 最初に白で塗りつぶす
        Color[] fillColor = new Color[textureWidth * textureHeight];
        for (int i = 0; i < fillColor.Length; i++)
        {
            fillColor[i] = Color.white; // 白色
        }
        texture.SetPixels(fillColor); // ピクセルを設定
        texture.Apply(); // 変更を適用

        // メッシュにテクスチャを適用
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = texture;
        }
    }

    // マウス位置に色を塗る
    public void PaintAtPosition(Vector2 position)
    {
        // 塗る範囲を指定（ブラシサイズ）
        int x = (int)(position.x * texture.width);
        int y = (int)(position.y * texture.height);

        // 範囲内でのみ色を塗る
        for (int i = -brushSize / 2; i <= brushSize / 2; i++)
        {
            for (int j = -brushSize / 2; j <= brushSize / 2; j++)
            {
                int newX = x + i;
                int newY = y + j;

                // 範囲内でのみ色を塗る
                if (newX >= 0 && newX < texture.width && newY >= 0 && newY < texture.height)
                {
                    texture.SetPixel(newX, newY, paintColor);
                }
            }
        }

        texture.Apply(); // 変更を適用
    }

    // 塗り始める
    public void StartPainting()
    {
        isPainting = true;
    }

    // 塗り終わる
    public void StopPainting()
    {
        isPainting = false;
    }

    public bool IsPainting()
    {
        return isPainting;
    }
}



}
