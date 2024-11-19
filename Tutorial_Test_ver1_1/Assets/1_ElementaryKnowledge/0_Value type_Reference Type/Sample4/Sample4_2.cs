//********************************************************
//* 参照型 を 参照渡し するパターン
//* (List<T>が参照型)
//********************************************************
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Value_and_Reference4
{

    public class Sample4_2 : MonoBehaviour
    {

        private void Start()
        {
            Ref_with_Value();
        }

        private void Ref_with_Value()
        {
            var list = new List<int>() { 2, 5, 1, -2 };// ①この時点で list は {2, 5, 1, -2 }
            Debug.Log($"①  {string.Join(",", list.Select(x => x.ToString()))}");

            EditListRef(ref list, 3);
            Debug.Log($"④  {string.Join(",", list.Select(x => x.ToString()))}");
            // ④この時点で list は {-2, 1, 2, 3, 5}
            // ※③で代入された参照が、外にも反映される
        }

        private void EditListRef(ref List<int> list, int val)
        {
            list.Add(val);
            Debug.Log($"②  {string.Join(",", list.Select(x => x.ToString()))}");
            // ②この時点で list は {2, 5, 1, -2, 3 }
            // ここのlistと外のlistはこの時点では同じヒープ上のメモリを指している

            list = list.OrderBy(x => x).ToList();
            Debug.Log($"③  {string.Join(",", list.Select(x => x.ToString()))}");
            // ↑ここのlistと外のlistが別のメモリを指すようになったが、
            // 　参照渡しされたlistに代入されたその参照は、外のlistにも反映される
            // ③この時点で list は {-2, 1, 2, 3, 5}
        }

    }
}