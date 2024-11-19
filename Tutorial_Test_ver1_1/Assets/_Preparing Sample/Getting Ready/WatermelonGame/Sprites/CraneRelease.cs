using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SampleGame2
{
    public class CraneRelease : MonoBehaviour
    {
        [SerializeField] GameObject releasePos;
        [SerializeField] GameObject allFruits;
        [SerializeField] GameObject nextPos;

        public void Release(InputAction.CallbackContext context) {            
            if (!context.performed) return;//ボタンを押して
   
            if (releasePos.transform.childCount != 1) return;//子要素があって

            //DropObjectクラスがあって
            if (!releasePos.transform.GetChild(0).TryGetComponent<FruitObject>(out var fruitObject)) return;

            //リリースできる状態にあれば
            if (fruitObject.fruitState == FruitObject.FruitState.READY)
            {
                //状態をFALLに変更　落ちている状態に
                fruitObject.fruitState = FruitObject.FruitState.FALL;

                //１か所の子要素にする
                fruitObject.transform.SetParent(allFruits.transform);

                //次　nextのObjectをReleasePosに持ってくる
                StartCoroutine(nextPos.transform.GetChild(0).GetComponent<FruitObject>().SetObject());
            }
        }
    }
}