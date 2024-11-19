using UnityEngine;

public class MoveAndPlayEffect : MonoBehaviour
{
    public ParticleSystem pSystem; // 再生するパーティクルシステム
    public float moveSpeed = 5f;          // 前進する速度
    public KeyCode moveKey = KeyCode.W;   // 前進トリガーとなるキー（デフォルトは W）



    public float decelerationRate = 0.95f; // 減速率（0.9〜0.99の範囲で調整）

    private bool isDecelerating = false; // 減速中かどうか

Rigidbody rb;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

    void Update()
    {
        // ボタンが押されている間
        if (Input.GetButton("Vertical"))
        {
            // 前方向に力を加える
            rb.AddForce(transform.forward * moveSpeed *Input.GetAxis("Vertical") , ForceMode.Force);
            isDecelerating = false; // 減速中ではない
        }
        else
        {
             // ボタンを離した際に減速を開始
            if (!isDecelerating)
            {
                isDecelerating = true;
            }

            // 慣性を持たせて速度を徐々に減らす
            rb.velocity *= decelerationRate;
            rb.angularVelocity *= decelerationRate;

            // 速度が十分に小さくなったら完全停止
            if (rb.velocity.magnitude < 0.0001f)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                isDecelerating = false;
            }
        }

//         // ボタンを押している間
//         if (Input.GetKey(moveKey))
//         {
//             // 前進
//             // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


// rb.AddForce(transform.forward*10f, ForceMode.Impulse);
//             // // パーティクルシステムが設定されていて、再生していない場合は再生
//             // if (pSystem != null && !pSystem.isPlaying)
//             // {
//             //     pSystem.Play();
//             // }

//             // isMoving = true; // フラグを更新
//         }
        // else
        // {
        //     // ボタンを離したときにパーティクルシステムを停止
        //     if (isMoving && pSystem != null && pSystem.isPlaying)
        //     {
        //         pSystem.Stop();
        //     }

        //     isMoving = false; // フラグをリセット
        // }
    }
}
