using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour {
    public Transform target;
    public float rotationSpeed = 1.0f;

    void Update() {
        // ターゲットに向けて一定速度で回転
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
    }
}