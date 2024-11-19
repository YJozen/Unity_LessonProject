using UnityEngine;
using TMPro;

public class Vector2Angle : MonoBehaviour
{
    [Header("Object Settings")]
    public Transform obj; // 回転させる対象のオブジェクト
    public TextMeshProUGUI tmp_text; // 角度を表示するテキスト

    [Header("Movement Settings")]
    public float rotationSpeed = 0.3f; // 回転のスピード
    public float radius = 4f; // 回転半径

    private float currentAngle = 0f; // 現在の角度

    void Update()
    {
        // 角度を進める
        currentAngle += rotationSpeed * Time.deltaTime;

        // オブジェクトの位置を角度に基づいて更新
        obj.position = CalculatePositionFromAngle(currentAngle, radius);

        // オブジェクトの位置から角度を計算
        float angle = CalculateAngleFromPosition(obj.position);

        // 角度を小数点第一位まで四捨五入
        float roundedAngle = Mathf.Round(angle * 10f) / 10f;

        // テキストに角度を表示
        tmp_text.text = $"{roundedAngle}";
    }

    /// <summary>
    /// 指定された角度（度）から、回転半径に基づいた位置を計算します。
    /// </summary>
    /// <param name="angle">角度（度）</param>
    /// <param name="radius">回転半径</param>
    /// <returns>計算された位置</returns>
    Vector3 CalculatePositionFromAngle(float angle, float radius)
    {
        float angleInRadians = angle * Mathf.Deg2Rad; // 度からラジアンに変換
        float x = Mathf.Cos(angleInRadians); // x座標
        float z = Mathf.Sin(angleInRadians); // z座標

        // y座標は固定で0、xとzの位置に基づいてオブジェクトを配置
        return new Vector3(x, 0f, z) * radius;
    }

    /// <summary>
    /// 与えられた位置から、その位置の角度を計算します。
    /// </summary>
    /// <param name="position">オブジェクトの位置</param>
    /// <returns>計算された角度（度）</returns>
    float CalculateAngleFromPosition(Vector3 position)
    {
        // atanを使って、x軸に対する角度（度）を計算
        return Mathf.Atan(position.z/position.x) * Mathf.Rad2Deg;
        // atan2を使って、x軸に対する角度（度）を計算
        // return Mathf.Atan2(position.z, position.x) * Mathf.Rad2Deg;
    }
}
