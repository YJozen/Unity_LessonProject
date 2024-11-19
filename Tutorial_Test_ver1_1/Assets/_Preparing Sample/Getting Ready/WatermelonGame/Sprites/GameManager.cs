using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame2
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]FruitObject prefab;
        [SerializeField]GameObject nextPos;
        public bool createFruit { get; set; }

        void Start()
        {
            FruitObject fruit = Instantiate(prefab, nextPos.transform.position, Quaternion.identity);
            fruit.transform.SetParent(nextPos.transform);
        }

        void Update()
        {
            //�����t���O�I���@���@nextPos�̎q�v�f�ɉ����Ȃ��Ƃ��@�V�K����
            if (createFruit && nextPos.transform.childCount == 0) {
                FruitObject fruit        = Instantiate(prefab, nextPos.transform.position, Quaternion.identity);
            }
        }
    }
}