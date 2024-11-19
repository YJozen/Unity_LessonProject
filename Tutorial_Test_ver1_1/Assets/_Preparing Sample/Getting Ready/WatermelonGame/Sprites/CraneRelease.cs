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
            if (!context.performed) return;//�{�^����������
   
            if (releasePos.transform.childCount != 1) return;//�q�v�f��������

            //DropObject�N���X��������
            if (!releasePos.transform.GetChild(0).TryGetComponent<FruitObject>(out var fruitObject)) return;

            //�����[�X�ł����Ԃɂ����
            if (fruitObject.fruitState == FruitObject.FruitState.READY)
            {
                //��Ԃ�FALL�ɕύX�@�����Ă����Ԃ�
                fruitObject.fruitState = FruitObject.FruitState.FALL;

                //�P�����̎q�v�f�ɂ���
                fruitObject.transform.SetParent(allFruits.transform);

                //���@next��Object��ReleasePos�Ɏ����Ă���
                StartCoroutine(nextPos.transform.GetChild(0).GetComponent<FruitObject>().SetObject());
            }
        }
    }
}