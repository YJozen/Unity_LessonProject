using UnityEngine;

public class DrawTexture : MonoBehaviour
{
    [SerializeField] private ComputeShader computeShader;
    [SerializeField] private Renderer planeRenderer;

    private int _kernelDrawTexture;
    private RenderTexture _renderTexture;

    private struct ThreadSize
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;
        public ThreadSize(uint x, uint y, uint z)
        {
            X = (int) x;
            Y = (int) y;
            Z = (int) z;
        }
    }
    private ThreadSize _kernelThreadSize;

    private void Start()
    {
        // RenderTextureの生成 
        //RenderTexture は、Unityで使用される特別な種類のテクスチャで、カメラの出力やその他のレンダリング結果をキャプチャするために使用されます
        _renderTexture = new RenderTexture(512, 512, 0, RenderTextureFormat.ARGB32);
        _renderTexture.enableRandomWrite = true;
        _renderTexture.Create(); //GPU上でレンダーテクスチャを初期化します。これにより、レンダーテクスチャが使用可能な状態になります。
        // RenderTexture を作成し、Compute Shaderで書き込みが可能なように enableRandomWrite プロパティを true に設定します。次に、Create メソッドを呼び出してGPU上にレンダーテクスチャを初期化します。






        // カーネル取得 動かす関数指定
        _kernelDrawTexture = computeShader.FindKernel("DrawTexture");

        // スレッドサイズの取得
        //カーネルのスレッドグループサイズを取得します。これにより、Dispatch メソッドを呼び出す際に必要なスレッドグループ数を計算できます。
        computeShader.GetKernelThreadGroupSizes(_kernelDrawTexture,
            out var threadSizeX,
            out var threadSizeY,
            out var threadSizeZ);
        _kernelThreadSize = new ThreadSize(threadSizeX, threadSizeY, threadSizeZ);

        // テクスチャの設定 動かす関数指定し、　     "textureBuffer" に RenderTexture を設定
        //Compute Shaderは指定されたRender Textureに対して読み書きができるようになります。
        computeShader.SetTexture(_kernelDrawTexture, "textureBuffer", _renderTexture);

        // カーネルの実行
        // 水平方向のグループ数: 512 / 8 = 64
        // それぞれのスレッドで設定する範囲を分担する
        //動かす処理　指定されたスレッドグループの数でシェーダーを実行します。スレッドグループの数は、レンダーテクスチャの幅と高さに基づいて計算されます。
        computeShader.Dispatch(
            _kernelDrawTexture,
            _renderTexture.width / _kernelThreadSize.X,
            _renderTexture.height / _kernelThreadSize.Y,
            _kernelThreadSize.Z);
        //カーネル実行の際に指定するグループ数は「幅/スレッド数」になります。
        //そうすることでスレッド実行ごとに描画する範囲を分担して処理することができます。


        // マテリアルに　テクスチャを設定
        planeRenderer.material.mainTexture = _renderTexture;
    }
}
