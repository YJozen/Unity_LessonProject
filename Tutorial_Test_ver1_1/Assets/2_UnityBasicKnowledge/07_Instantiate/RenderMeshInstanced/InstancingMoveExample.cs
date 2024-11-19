using UnityEngine;

public class InstancingMoveExample : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int instanceCount = 100;
    private Matrix4x4[] matrices; // 各インスタンスの行列
    private Vector3[] positions;  // 各インスタンスの位置
    private Vector3[] velocities; // 各インスタンスの速度

    private Quaternion[] rotations;  // 各インスタンスの回転
    private Vector3[] scales;        // 各インスタンスのスケール

    void Start()
    {
        matrices = new Matrix4x4[instanceCount];
        positions = new Vector3[instanceCount];
        velocities = new Vector3[instanceCount];

        rotations = new Quaternion[instanceCount];
        scales = new Vector3[instanceCount];

        // 初期位置と速度を設定
        for (int i = 0; i < instanceCount; i++)
        {
            // ランダムな位置と速度を設定
            positions[i] = new Vector3(i * 1.1f, Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            velocities[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        
            // ランダムな初期回転とスケールを設定
            rotations[i] = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            scales[i] = new Vector3(Random.Range(0.5f, 2f), Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));   
        }
    }

    void Update()
    {
        // 各インスタンスの位置を更新し、行列を設定
        for (int i = 0; i < instanceCount; i++)
        {
            // 位置を更新
            positions[i] += velocities[i] * Time.deltaTime;

            // 画面内に収めるために制限
            if (positions[i].x > 10 || positions[i].x < -10) velocities[i].x = -velocities[i].x;
            if (positions[i].y > 10 || positions[i].y < -10) velocities[i].y = -velocities[i].y;
            if (positions[i].z > 10 || positions[i].z < -10) velocities[i].z = -velocities[i].z;

            // 回転を時間に応じて変化させる
            rotations[i] *= Quaternion.Euler(0, 30f * Time.deltaTime, 0);

            // 各インスタンスの位置と回転、スケールを行列に反映
            matrices[i] = Matrix4x4.TRS(
                positions[i],     // 位置
                rotations[i],     // 回転
                scales[i]         // スケール
            );
        }

        // インスタンシングを使って描画
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices);
    }
}
