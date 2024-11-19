using System.Collections.Generic;
using UnityEngine;

public class BallSimulation : MonoBehaviour
{
    [Header("Simulation Settings")]
    public GameObject ball;                // 操作対象のボールオブジェクト
    public float simulateStep = 0.02f;     // 物理シミュレーションの1ステップ時間
    public int futureSteps = 100;          // 未来予測のシミュレーションステップ数

    [Header("Visualization")]
    public LineRenderer lineRenderer;      // 未来予測用のラインレンダラー
    public LayerMask obstacleMask;         // 障害物のレイヤーマスク

    private Rigidbody ballRb;
    private Vector3 initialVelocity;       // 初速
    private List<Vector3> pastPositions;   // 過去の位置を保存
    private List<Vector3> pastVelocities;  // 過去の速度を保存

    void Start()
    {
        InitializeBall();
        InitializeLineRenderer();
        InitializeStateTracking();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) AdvanceSimulation();
        if (Input.GetKey(KeyCode.B)) ReversePlayback();
        if (Input.GetKey(KeyCode.C)) SimulateFutureTrajectory();
    }

    // ボールの初期化
    private void InitializeBall()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        initialVelocity = new Vector3(1.0f, 5.0f, 0.0f);
        ballRb.velocity = initialVelocity;
    }

    // ラインレンダラーの初期化
    private void InitializeLineRenderer()
    {
        lineRenderer.positionCount = futureSteps;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        Material lineMaterial = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material = lineMaterial;
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.blue;
    }

    // 状態保存の初期化
    private void InitializeStateTracking()
    {
        pastPositions = new List<Vector3>();
        pastVelocities = new List<Vector3>();
    }

    // シミュレーションを進める
    private void AdvanceSimulation()
    {
        RecordState();
        Physics.Simulate(simulateStep);
    }

    // 現在の位置と速度を記録する
    private void RecordState()
    {
        pastPositions.Add(ball.transform.position);
        pastVelocities.Add(ballRb.velocity);
    }

    // 逆再生を行う
    private void ReversePlayback()
    {
        if (pastPositions.Count == 0 || pastVelocities.Count == 0) return;

        ball.transform.position = pastPositions[^1];
        ballRb.velocity = pastVelocities[^1];

        pastPositions.RemoveAt(pastPositions.Count - 1);
        pastVelocities.RemoveAt(pastVelocities.Count - 1);
    }

    // 未来の軌道を予測する
    private void SimulateFutureTrajectory()
    {
        // 元の状態を保存
        SaveBallState(out Vector3 originalPosition, out Quaternion originalRotation, out Vector3 originalVelocity, out Vector3 originalAngularVelocity);

        // シミュレーション用の位置リスト
        List<Vector3> futurePositions = new List<Vector3>();
        float bounciness = GetBallBounciness();

        // 未来予測をシミュレーション
        for (int i = 0; i < futureSteps; i++)
        {
            Physics.Simulate(simulateStep);
            futurePositions.Add(ball.transform.position);

            if (CheckCollision(out RaycastHit hit))
            {
                Vector3 reflectDirection = Vector3.Reflect(ballRb.velocity, hit.normal);
                ballRb.velocity = reflectDirection * bounciness;
            }
        }

        // 元の状態にリセット
        RestoreBallState(originalPosition, originalRotation, originalVelocity, originalAngularVelocity);

        // ラインレンダラーに軌道を描画
        lineRenderer.positionCount = futurePositions.Count;
        lineRenderer.SetPositions(futurePositions.ToArray());
    }

    // 衝突判定を行う
    private bool CheckCollision(out RaycastHit hit)
    {
        return Physics.Raycast(ball.transform.position, ballRb.velocity.normalized, out hit, ballRb.velocity.magnitude * simulateStep, obstacleMask);
    }

    // ボールの反発係数を取得
    private float GetBallBounciness()
    {
        return ball.GetComponent<Collider>().material.bounciness;
    }

    // ボールの状態を保存
    private void SaveBallState(out Vector3 position, out Quaternion rotation, out Vector3 velocity, out Vector3 angularVelocity)
    {
        position = ball.transform.position;
        rotation = ball.transform.rotation;
        velocity = ballRb.velocity;
        angularVelocity = ballRb.angularVelocity;
    }

    // ボールの状態を復元
    private void RestoreBallState(Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity)
    {
        ball.transform.position = position;
        ball.transform.rotation = rotation;
        ballRb.velocity = velocity;
        ballRb.angularVelocity = angularVelocity;
    }
}
