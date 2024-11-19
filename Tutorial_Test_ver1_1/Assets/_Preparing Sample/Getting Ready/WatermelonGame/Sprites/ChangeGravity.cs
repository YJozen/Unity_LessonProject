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
            rBody.useGravity = false; //�ŏ���rigidBody�̏d�͂��g��Ȃ�����
        }

        private void FixedUpdate()
        {
            if (useGravity)
            SetLocalGravity(); //�d�͂�AddForce�ł����郁�\�b�h���ĂԁBFixedUpdate���D�܂����B
        }

        private void SetLocalGravity()
        {
            rBody.AddForce(localGravity, ForceMode.Acceleration);
        }
    }

}