using UnityEngine;

public class InstancingIndirectExample : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int instanceCount = 1000;
    private ComputeBuffer argsBuffer;

    private void Start()
    {
        // 間接描画用の引数バッファを作成
        uint[] args = new uint[5] { mesh.GetIndexCount(0), (uint)instanceCount, 0, 0, 0 };
        argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        argsBuffer.SetData(args);
    }

    private void OnDisable()
    {
        // 使用後バッファを解放
        if (argsBuffer != null) argsBuffer.Release();
    }

    private void Update()
    {
        // インスタンシング描画
        Graphics.DrawMeshInstancedIndirect(mesh, 0, material, new Bounds(Vector3.zero, Vector3.one * 1000), argsBuffer);
    }
}
