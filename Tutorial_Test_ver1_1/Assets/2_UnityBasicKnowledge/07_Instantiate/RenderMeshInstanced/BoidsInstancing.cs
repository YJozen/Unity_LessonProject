using UnityEngine;

public class BoidsInstancing : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int boidCount = 100;
    public float boidSpeed = 1.0f;
    public Vector3 boundsSize = new Vector3(10f, 10f, 10f); // 立方体のサイズ
    public float separationDistance = 1.5f; // 分離距離
    public float alignmentDistance = 5f;     // 整列距離
    public float cohesionDistance = 5f;      // 結合距離
    public float randomMovementFactor = 0.2f; // ランダム移動の影響度（減少）

    private Vector3[] positions;     // 各Boidの位置
    private Vector3[] velocities;    // 各Boidの速度
    private Matrix4x4[] matrices;    // 各Boidの行列
    private Quaternion[] rotations;  // 各Boidの回転

    void Start()
    {
        positions = new Vector3[boidCount];
        velocities = new Vector3[boidCount];
        matrices = new Matrix4x4[boidCount];
        rotations = new Quaternion[boidCount];

        // 各Boidの初期化
        for (int i = 0; i < boidCount; i++)
        {
            positions[i] = new Vector3(Random.Range(-boundsSize.x / 2, boundsSize.x / 2),
                                        Random.Range(-boundsSize.y / 2, boundsSize.y / 2),
                                        Random.Range(-boundsSize.z / 2, boundsSize.z / 2));
            velocities[i] = Random.insideUnitSphere.normalized * boidSpeed; // 初期速度をランダムに設定
            rotations[i] = Quaternion.LookRotation(velocities[i]);
        }
    }

    void Update()
    {
        for (int i = 0; i < boidCount; i++)
        {
            // Boidsアルゴリズムに基づいて位置と速度を更新
            UpdateBoid(i);

            // Boidの回転を速度に合わせて更新
            rotations[i] = Quaternion.LookRotation(velocities[i]);

            // 行列に位置、回転、スケールを設定
            matrices[i] = Matrix4x4.TRS(positions[i], rotations[i], Vector3.one);
        }

        // メッシュをインスタンス化して描画
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices, boidCount);
    }

    void UpdateBoid(int index)
    {
        Vector3 separation = Vector3.zero;
        Vector3 alignment = Vector3.zero;
        Vector3 cohesion = Vector3.zero;

        int neighborCount = 0;

        for (int i = 0; i < boidCount; i++)
        {
            if (i == index) continue;

            float distance = Vector3.Distance(positions[index], positions[i]);

            // 近すぎる場合は分離（Separation）
            if (distance < separationDistance)
            {
                separation += positions[index] - positions[i];
            }

            // 一定の距離内のBoidに基づいて整列と結合（Alignment, Cohesion）
            if (distance < alignmentDistance)
            {
                alignment += velocities[i];
                neighborCount++;
            }
            if (distance < cohesionDistance)
            {
                cohesion += positions[i];
                neighborCount++;
            }
        }

        if (neighborCount > 0)
        {
            alignment /= neighborCount; // 平均速度
            alignment = (alignment - velocities[index]).normalized; // 整列

            cohesion = (cohesion / neighborCount - positions[index]).normalized; // 結合
        }

        // 各力を合成して速度を更新
        Vector3 desiredVelocity = velocities[index] + (separation * 1.0f + alignment * 0.5f + cohesion * 0.5f) * Time.deltaTime; // 力のバランスを調整
        velocities[index] = Vector3.ClampMagnitude(desiredVelocity, boidSpeed); // 最大速度を制限

        // ランダムな動きを追加（減少した影響度）
        velocities[index] += new Vector3(Random.Range(-randomMovementFactor, randomMovementFactor), 
                                           Random.Range(-randomMovementFactor, randomMovementFactor), 
                                           Random.Range(-randomMovementFactor, randomMovementFactor));

        // 位置を更新
        positions[index] += velocities[index] * Time.deltaTime;

        // 立方体の境界で反射させる
        ReflectBoidInBounds(ref positions[index], ref velocities[index]);
    }

    void ReflectBoidInBounds(ref Vector3 position, ref Vector3 velocity)
    {
        // 立方体の境界を考慮して、越えた場合に速度を反転
        if (position.x < -boundsSize.x / 2)
        {
            position.x = -boundsSize.x / 2; // 位置を修正
            velocity.x *= -1; // 反転
        }
        else if (position.x > boundsSize.x / 2)
        {
            position.x = boundsSize.x / 2; // 位置を修正
            velocity.x *= -1; // 反転
        }

        if (position.y < -boundsSize.y / 2)
        {
            position.y = -boundsSize.y / 2; // 位置を修正
            velocity.y *= -1; // 反転
        }
        else if (position.y > boundsSize.y / 2)
        {
            position.y = boundsSize.y / 2; // 位置を修正
            velocity.y *= -1; // 反転
        }

        if (position.z < -boundsSize.z / 2)
        {
            position.z = -boundsSize.z / 2; // 位置を修正
            velocity.z *= -1; // 反転
        }
        else if (position.z > boundsSize.z / 2)
        {
            position.z = boundsSize.z / 2; // 位置を修正
            velocity.z *= -1; // 反転
        }
    }
}
