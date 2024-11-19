using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SampleGame2 {
    public class CraneMove : MonoBehaviour
    {
        float inputX;
        [SerializeField]float speedX = 3f;
        Vector2 crane_InitialPos = new Vector2(0,4.5f);
        [SerializeField]float posX_limit = 1.5f;

        void Start()
        {
            transform.position = crane_InitialPos;
        }

        void Update()
        {
            transform.position += transform.right * inputX * speedX * Time.deltaTime;

            //�N���[���̈ړ�����
            float posX = transform.position.x;//�N���[���̌��݂̍��W
            posX = Mathf.Clamp(posX,-posX_limit,posX_limit);
            transform.position = new Vector3(posX,crane_InitialPos.y,0);//������̍��W��K��������
        }

        public void Move(InputAction.CallbackContext context)
        {
            inputX = context.ReadValue<float>();            
        }
    }
}

