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
        public FruitState fruitState = FruitState.NEXT;//生成したらNext状態に

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            changeGravity = GetComponent<ChangeGravity>();
        }

        void Update()
        {
            switch (fruitState) {
                case FruitState.NEXT:
                    //ネクスト位置に持ってくる　その他 初期状態に
                    rb.isKinematic = false;
                    transform.position = nextPos.transform.position;
                    changeGravity.useGravity = false;
                    break;

                case FruitState.READY:
                    //Releaseする前の状態　                
                    transform.position = releasePos.transform.position;
                    break;

                case FruitState.FALL:
                    //Release後　落としている状態
                    rb.isKinematic = true;
                    break;

                case FruitState.STAY:
                    //落ち切った状態
                    changeGravity.useGravity = true;
                
                    break;
            }
        }

        //Next Object　を　Release　Objectに
        public IEnumerator SetObject() {
            if (fruitState == FruitState.NEXT) {
                yield return new WaitForSeconds(0.8f);//0.8秒待機
                transform.SetParent(releasePos.transform);
                Invoke("ReadyCreate",0.2f);
            }
        }

        void ReadyCreate() { 
            gameManager.createFruit = true;
        }
    }
}