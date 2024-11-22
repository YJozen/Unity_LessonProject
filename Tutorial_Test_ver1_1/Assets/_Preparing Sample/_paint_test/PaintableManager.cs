namespace PaintableTest {

using UnityEngine;

public class PaintableManager : MonoBehaviour
{
    public Paintable paintable;
    public PaintCameraController paintCameraController;

    void Update()
    {
        // 塗る開始・終了
        if (Input.GetMouseButtonDown(0)) // 左クリックで塗り始める
        {
            paintable.StartPainting();
        }
        else if (Input.GetMouseButtonUp(0)) // 左クリックを離すと塗り終わり
        {
            paintable.StopPainting();
        }

        // 塗り処理
        if (paintable.IsPainting())
        {
            // マウス位置をワールド座標に変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 塗る処理
                Renderer rend = hit.collider.GetComponent<Renderer>();
                if (rend != null)
                {
                    Vector2 uv = hit.textureCoord; // UV座標
                    paintable.PaintAtPosition(uv);
                }
            }
        }

        // 塗られた割合を計算
        float paintedPercentage = paintCameraController.CalculatePaintedPercentage();
        Debug.Log("塗られた割合: " + paintedPercentage + "%");
    }
}


}