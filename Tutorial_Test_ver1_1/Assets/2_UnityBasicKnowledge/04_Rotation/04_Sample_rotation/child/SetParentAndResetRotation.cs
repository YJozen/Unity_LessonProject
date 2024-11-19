using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentAndResetRotation : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject childObject;

    void Start()
    {
        // 子オブジェクトを親オブジェクトの子に設定する
        childObject.transform.SetParent(parentObject.transform);

        // 子オブジェクトのローカル回転をゼロに設定する
        childObject.transform.localRotation = Quaternion.identity;
    }
}
