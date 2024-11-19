using NovelGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SampleGame2
{
    public class FruitObject : MonoBehaviour
    {
        Rigidbody rb;
        ChangeGravity changeGravity;
        [SerializeField] GameManager gameManager;
        public Transform nextPos;
        [SerializeField] GameObject releasePos;

        public enum FruitState
        {
            NEXT, READY, FALL, STAY
        }
        public FruitState fruitState = FruitState.NEXT;//����������Next��Ԃ�

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            changeGravity = GetComponent<ChangeGravity>();
        }

        void Update()
        {
            switch (fruitState) {
                case FruitState.NEXT:
                    //�l�N�X�g�ʒu�Ɏ����Ă���@���̑� ������Ԃ�
                    rb.isKinematic = false;
                    transform.position = nextPos.transform.position;
                    changeGravity.useGravity = false;
                    break;

                case FruitState.READY:
                    //Release����O�̏�ԁ@                
                    transform.position = releasePos.transform.position;
                    break;

                case FruitState.FALL:
                    //Release��@���Ƃ��Ă�����
                    rb.isKinematic = true;
                    break;

                case FruitState.STAY:
                    //�����؂������
                    changeGravity.useGravity = true;
                
                    break;
            }
        }

        //Next Object�@���@Release�@Object��
        public IEnumerator SetObject() {
            if (fruitState == FruitState.NEXT) {
                yield return new WaitForSeconds(0.8f);//0.8�b�ҋ@
                transform.SetParent(releasePos.transform);
                Invoke("ReadyCreate",0.2f);
            }
        }

        void ReadyCreate() { 
            gameManager.createFruit = true;
        }
    }
}