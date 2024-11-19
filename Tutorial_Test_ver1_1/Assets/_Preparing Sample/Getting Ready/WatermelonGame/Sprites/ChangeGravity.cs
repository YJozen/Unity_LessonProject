using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame2
{
    public class ChangeGravity : MonoBehaviour
    {
        [SerializeField] private Vector3 localGravity = new Vector3(0,-10,0);
        private Rigidbody rBody;
        public bool useGravity { get; set; }

        private void Start()
        {
            rBody = this.GetComponent<Rigidbody>();
            rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
        }

        private void FixedUpdate()
        {
            if (useGravity)
            SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
        }

        private void SetLocalGravity()
        {
            rBody.AddForce(localGravity, ForceMode.Acceleration);
        }
    }

}