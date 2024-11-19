using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoExample : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Gizmosの色を設定
        Gizmos.color = Color.red;
        
        // オブジェクトの位置に球を描画
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
