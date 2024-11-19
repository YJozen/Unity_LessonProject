//********************************************************
//* 参照型 を 値渡し するパターン
//* (List<T>が参照型)
//********************************************************
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Value_and_Reference4
{

    public class Sample4_1 : MonoBehaviour
    {

        private void Start()
        {
            Ref_with_Value();
        }

        private void Ref_with_Value()
        {
            var list = new List<int>() { 2, 5, 1, -2 }; // ①この時点で list は {2, 5, 1, -2 }
            Debug.Log($"①  {string.Join(",", list.Select(x => x.ToString()))}");



            EditListRef(list, 3);
            Debug.Log($"④  {string.Join(",", list.Select(x => x.ToString()))}");
            // ④この時点で list は {2, 5, 1, -2, 3 }
            // ※③で値渡しされた参照を書き換えても外のlistには反映されない
        }

        private void EditListRef(List<int> list, int val)
        {
            list.Add(val);
            Debug.Log($"②  {string.Join(",", list.Select(x => x.ToString()))}");
            // ②この時点で list は {2, 5, 1, -2, 3 }
            // ここのlistと外のlistはこの時点では同じヒープ上のメモリを指している



            list = list.OrderBy(x => x).ToList();
            Debug.Log($"③  {string.Join(",", list.Select(x => x.ToString()))}");
            // ③OrderByで新しい領域が確保され、そこへの参照がlistに入れられる。
            // が、listは値渡しされたものであるので、引数の渡し元へは反映されない。
            // この時点で list は {-2, 1, 2, 3, 5} でソートされてるが、
            // 値渡しされたlistの参照先は、呼び出し元のlist(参照型)には反映されない
        }

    }
}