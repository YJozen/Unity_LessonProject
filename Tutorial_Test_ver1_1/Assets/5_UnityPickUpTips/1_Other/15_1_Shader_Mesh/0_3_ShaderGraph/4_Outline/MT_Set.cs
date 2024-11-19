using UnityEngine;

public class MT_Set : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    void Start()
    {
        // MeshRendererコンポーネントを取得
        meshRenderer = GetComponent<MeshRenderer>();
        
        // マテリアルを設定
        SetRenderQueueAndZWrite();
    }

    void SetRenderQueueAndZWrite()
    {
        // MeshRendererからすべてのマテリアルを取得
        Material[] materials = meshRenderer.materials;

        // 各マテリアルに対してRender QueueとZWriteを設定
        foreach (var mat in materials)
        {
            Debug.Log(mat.name);

            // Render Queueを設定 (例: 3100 - Overlay)
            mat.renderQueue = 4100;

            Debug.Log(mat.renderQueue);

            // ZWriteを無効にする
            mat.SetInt("_ZWrite", 0);  // ZWriteの無効化

            // ZTestをAlwaysに設定（オプション）
            mat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
        }
    }
}
