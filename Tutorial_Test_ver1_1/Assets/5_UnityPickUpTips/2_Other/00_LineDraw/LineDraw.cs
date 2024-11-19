using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public LineRenderer _rend;
    private int posCount = 0;
    private float interval = 0.1f;

    private void Start() {
        _rend = GetComponent<LineRenderer>();
    }

    //スタート位置　
    public void StartPosition(Vector2 pos) {
        posCount = 0;
        _rend.positionCount = 1;  
        _rend.SetPosition(0, pos);//
    }

    public void AddPosition(Vector2 pos) {
        if (!PosCheck(pos)) return;

        posCount++;                          //
        _rend.positionCount = posCount;      //
        _rend.SetPosition(posCount - 1, pos);//
    }

    private bool PosCheck(Vector2 pos) {
        if (posCount == 0) return true;

        float distance = Vector2.Distance(_rend.GetPosition(posCount - 1), pos);
        if (distance > interval)
            return true;
        else
            return false;
    }
}