using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrefabRef
{

    public class PrefabObject : MonoBehaviour
    {
        //�q�G�����L�[�̏����Z�b�g�ł��Ȃ��i������Ƃ��āA�������ɃA�h���X�����擾����j
        [SerializeField] HierarchyObject hierarchyObject;//�C���X�y�N�^�[�ŃZ�b�g�ł��Ȃ�

        void Update()
        {        
            Debug.Log(hierarchyObject.hp);
        }

        public void SetHierarchyObject(HierarchyObject hObject)
        {
            this.hierarchyObject = hObject;    
        }
    }

}


