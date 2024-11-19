using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bring_Sample
{
    public class ItemObject : MonoBehaviour
    {
        Rigidbody rb;

        public bool isReleased { get; set; }           //プロパティ利用した場合の書き方
        [NonSerialized] public GameObject playerObject;//NonSerialized利用した場合の書き方

        void Start() {
            isReleased = false;
            rb = GetComponent<Rigidbody>(); 
        }
        void Update() {
            if (isReleased) {
                rb.isKinematic = false;
                rb.velocity  = playerObject.transform.forward * 10.0f; //親の向きに発射
                Destroy(this.gameObject, 1.0f);
            }    
        }
    }
}