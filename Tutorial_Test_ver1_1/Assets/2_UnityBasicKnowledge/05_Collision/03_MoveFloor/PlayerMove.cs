using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloorMove_Sample
{
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody rb;
        float upForce = 100f;
        [SerializeField]GameObject parentObj;

        void Start() {
            rb = GetComponent<Rigidbody>();
            parentObj = GameObject.Find("FloorRoot");
        }

        void Update() {
            if (Input.GetMouseButtonDown(0))
                rb.AddForce(new Vector3(0, upForce, 0));
        }

        void OnCollisionEnter(Collision other) {
            if (other.gameObject.name == "FloorObject")
                transform.SetParent(parentObj.transform);
        }

        void OnCollisionExit(Collision other) {
            if (other.gameObject.name == "FloorObject")
                transform.SetParent(null);
        }
    }
}