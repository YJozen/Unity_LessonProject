using UnityEngine;

public class LineTracer : MonoBehaviour
{
    [SerializeField] private LineDraw _linedraw;

    private Vector3[] positions;//位置情報に関する　配列

    private bool isMove;
    private Vector3 target;
    private int index = 0;
    private float speed = 5.0f;

    private void Start() {
        isMove = false;//オブジェクトを動かすためのフラグをオフにしておく
    }
    private void OnMouseDown() {//マウスを押した時に呼び出す
        index = 0;
        _linedraw.StartPosition(transform.position);//スタート位置　今回はこのスクリプトを貼り付けたオブジェクト
    }

    private void OnMouseDrag() {//マウスを押しっぱなしの時に呼び出す
        _linedraw.AddPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));//
    }

    private void OnMouseUp() {//マウスを離した時に呼び出す
        positions = new Vector3[_linedraw._rend.positionCount];//線を引くためのリストの数
        _linedraw._rend.GetPositions(positions);
        isMove = true;
    }

    private void Update() {
        if (!isMove) return;//動かすかどうか　動かさないなら次へ

        if (Vector2.Distance(target, transform.position) <= 0.1f) {//距離が近いなら
            if (index >= positions.Length - 1)//index 線を引くための位置情報配列の数の番号を超えたら
                isMove = false;               //動かないように変更

            if (index != positions.Length - 1) {//index 線を引くための位置情報配列の数　と違うなら
                index++;                  //
                target = positions[index];//配列
            }
        }

        //このオブジェクト　を　ターゲット位置まで動かす　
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}