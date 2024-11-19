using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Bring_Sample
{
    public class Hand : MonoBehaviour
    {
        bool grabed;//掴んでいたらtrue
        GameObject itemObject;

        void Start() {
            grabed = false;
        }

        void Update() {
            if (Input.GetKeyUp(KeyCode.Space) && grabed) {        
                itemObject = transform.GetChild(0).gameObject;//アイテムObject取得
                itemObject.GetComponent<ItemObject>().playerObject = transform.root.gameObject;//一番上の親要素取得
                itemObject.transform.parent = null;//子要素の親子関係を断つ
                grabed = false;
                itemObject.GetComponent<ItemObject>().isReleased = true;               
            }
        }

        void OnTriggerStay(Collider col) {
            if (Input.GetKeyDown(KeyCode.Space)
                && col.gameObject.TryGetComponent<ItemObject>(out ItemObject item)
                && !grabed)
            {
                grabed = true;
                item.gameObject.transform.position = this.transform.position;
                item.gameObject.transform.SetParent(this.transform);
            }
        }
    }
}