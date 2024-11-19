using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour {
    public Transform target;
    public float lerpSpeed = 1.0f;

    void Update() {
        // 現在の回転とターゲットの回転の間を線形補間する
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerpSpeed * Time.deltaTime);
    }
}
