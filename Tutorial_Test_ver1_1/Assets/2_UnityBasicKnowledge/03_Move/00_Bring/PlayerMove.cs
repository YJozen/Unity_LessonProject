using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bring_Sample
{
    public class PlayerMove : MonoBehaviour
    {

        public float speed = 3.0F;
        public float rotateSpeed = 3.0F;

        void Update() {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);


            CharacterController controller = GetComponent<CharacterController>();
           
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            //書き方は変な気もするが(Vector3.forwardはワールド座標系での前方なのに...)　　　　
            //ローカル座標系の前方をワールド座標系に変換してる

            float curSpeed = speed * Input.GetAxis("Vertical");

            controller.SimpleMove(forward * curSpeed);
            //実際の移動に使われているプログラム
            //SimpleMoveという関数を使うことで重力も勝手につけてくれる　
            //[Edit] > [Project Settings] > [Physics] の [Gravity] の [Y]
            //またSimpleMoveは引数にワールド座標系を使う必要がある
        }
    }

}