using UnityEngine;

public class InstancingExample : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int instanceCount = 100;

    void Update()
    {
        // インスタンス化するオブジェクトのトランスフォームを保存する配列
        Matrix4x4[] matrices = new Matrix4x4[instanceCount];

        for (int i = 0; i < instanceCount; i++)
        {
            // 配列に各オブジェクトのワールド空間での位置を設定
            matrices[i] = Matrix4x4.TRS(
                new Vector3(i * 1.1f, 0, 0), // 位置
                Quaternion.identity,         // 回転
                Vector3.one                  // スケール
            );
        }

        // インスタンシングによって複数のメッシュを描画
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices);
    }
}
