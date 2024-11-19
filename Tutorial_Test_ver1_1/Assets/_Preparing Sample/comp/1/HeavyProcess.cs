using UnityEngine;

public class HeavyProcess : MonoBehaviour
{
    [SerializeField] private ComputeShader computeShader;
    private int _kernelHeavyProcess;
    private ComputeBuffer _intComputeBuffer;

    private void Start()
    {
        // カーネル取得
        _kernelHeavyProcess = computeShader.FindKernel("HeavyProcess");

        // Buffer領域を確保
        _intComputeBuffer = new ComputeBuffer(64, sizeof(int));

        // パラメータの設定　
        computeShader.SetInt("intValue", 1);
        computeShader.SetBuffer(_kernelHeavyProcess, "intBuffer", _intComputeBuffer);
    }

    private void Update()
    {
        // GroupIDを指定して数回実行
        // (64,1,1)スレッド * (1,1,1)グループ
        computeShader.Dispatch(_kernelHeavyProcess, 1, 1, 1);

        // 実行結果
        var result = new int[64];
        _intComputeBuffer.GetData(result);
        Debug.Log("RESULT: HeavyProcess");
        for (var i = 0; i < 64; i++)
        {
            Debug.Log(i + ":　" + result[i]);
        }
    }

    private void OnDestroy()
    {
        // バッファの解放
        _intComputeBuffer.Release();
    }
}
