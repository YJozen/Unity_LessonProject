using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;       // 最大駆動力
    public float maxSteeringAngle;     // 最大ステアリング角
    public float brakeTorque = 3000f;  // ブレーキ力
    public float decelerationSpeed = 500f;  // アクセルを離した時の減速力
    public float stopThreshold = 0.1f; // 停止判定のしきい値

    float motor;
    float steering;
    float currentSpeed;

    void Update()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
    }

    public void FixedUpdate() {
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                // 車速を取得
                currentSpeed = axleInfo.leftWheel.rpm * axleInfo.leftWheel.radius * Mathf.PI / 30.0f;

                // ブレーキの処理
                if (Input.GetKey(KeyCode.Space)) {
                    // ブレーキボタンを押した時に強めのブレーキをかける
                    ApplyBrake(axleInfo, brakeTorque);
                } else if (motor == 0 && Mathf.Abs(currentSpeed) > stopThreshold) {
                    // アクセルを離した時、自然な減速を行う
                    ApplyBrake(axleInfo, decelerationSpeed);
                } else if (motor < 0 && currentSpeed > 0 || motor > 0 && currentSpeed < 0) {
                    // 逆方向に入力があった場合、強めのブレーキをかける
                    ApplyBrake(axleInfo, brakeTorque);
                } else {
                    // ブレーキが不要な場合は解除
                    ReleaseBrake(axleInfo);
                    // 駆動力をホイールに適用
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        }
    }

    // ブレーキを適用するメソッド
    private void ApplyBrake(AxleInfo axleInfo, float brakeForce) {
        axleInfo.leftWheel.brakeTorque = brakeForce;
        axleInfo.rightWheel.brakeTorque = brakeForce;
        axleInfo.leftWheel.motorTorque = 0;
        axleInfo.rightWheel.motorTorque = 0;
    }

    // ブレーキを解除するメソッド
    private void ReleaseBrake(AxleInfo axleInfo) {
        axleInfo.leftWheel.brakeTorque = 0;
        axleInfo.rightWheel.brakeTorque = 0;
    }

    // ホイールのビジュアル位置を更新するメソッド
    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // 駆動輪か?
    public bool steering; // ハンドル操作をしたときに角度が変わるか？
}
