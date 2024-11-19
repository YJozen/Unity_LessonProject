using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

namespace KnockBack
{
    public class CollisionRigidbody : MonoBehaviour
    {
        Rigidbody rb;


    public float force = 1f;
    public float duration = 0.5f;
    public float damping = 1f;


        private void Start()
        {
            rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.CompareTag("Enemy")) {

                Debug.Log("当たった");

                
                // rb.AddForce(-transform.right * 2f, ForceMode.VelocityChange);//質量を無視
                // rb.AddForce(-transform.right * 2f, ForceMode.Impulse);
                rb.useGravity = true;  
                Vector3 direction = new Vector3(-transform.right.x , transform.up.y ,0f );
                rb.AddForce(direction * 6f, ForceMode.Impulse);
                          
            }
        }
    }
}


//Collision 変数例
//collider 　　　ヒットした Collider 情報を返します（読み取り専用）
//contactCount	Gets the number of contacts for this collision.
//contacts	　　The contact points generated by the physics engine. You should avoid using this as it produces memory garbage. Use GetContact or GetContacts instead.
//gameObject	The GameObject whose collider you are colliding with. (Read Only).
//impulse       衝突を解消するために互いの接触に適用される合計のインパルス
//relativeVelocity	衝突した 2 つのオブジェクトの相対的な速度（読み取り専用）
//rigidbody	ヒットした Rigidbody （読み取り専用）。
//          ヒットしたオブジェクトに Rigidbody がアタッチされていない場合、null を返します。
//transform	ヒットした Transform 情報を返します。（読み取り専用）