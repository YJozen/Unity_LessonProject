using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionDirectRotation : MonoBehaviour {
    public float rotationSpeed = 100f;

    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        // 直接クォータニオンで回転
        Quaternion deltaRotation = Quaternion.AngleAxis(inputX * rotationSpeed * Time.deltaTime, Vector3.up);
        transform.rotation = transform.rotation * deltaRotation;
    }
}
