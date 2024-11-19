using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrefabRef
{

    public class PrefabObject : MonoBehaviour
    {
        //ヒエラルキーの情報をセットできない（解決策として、生成時にアドレス情報を取得する）
        [SerializeField] HierarchyObject hierarchyObject;//インスペクターでセットできない

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


