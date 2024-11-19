using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransform_move : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 targetPosition = new Vector2(500, 500);
    float moveSpeed = 1.0f;

    void Start() {
        rectTransform = GetComponent<RectTransform>();           // RectTransformの取得        
        rectTransform.anchoredPosition = new Vector2(-500, -500);// 新しい座標に移動
    }

    void Update() {
        // RectTransformのanchoredPositionをVector2からVector3に変換
        Vector3 currentPosition = rectTransform.anchoredPosition;

        // 目標の座標まで移動する
        rectTransform.anchoredPosition = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed*Time.deltaTime);
        //rectTransform.anchoredPosition = Vector3.Lerp(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
