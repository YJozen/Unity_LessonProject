using UnityEngine;

public class TargetNavi : MonoBehaviour
{
    [SerializeField] private Transform target;//ターゲット
    // private Rect viewRect;

    void Start()
    {
        // viewRect = GetComponent<RectTransform>().rect;//画面サイズ取得
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);//ワールド座標をスクリーン座標に変換
        transform.position = screenPos;
    }
}
