using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class cellInfo
{
    public Vector3 pos { get; set; }        // 対象の位置情報(タイルのpivot)
    public float cost { get; set; }         // 実コスト(今まで何歩歩いたか)
    public float heuristic { get; set; }    // 推定コスト(ゴールまでの距離)
    public float sumConst { get; set; }     // 総コスト = 実コスト + 推定コスト
    public Vector3 parent { get; set; }     // 親セルの位置情報(各処理におけるスタート地点)
    public bool isOpen { get; set; }        // 調査対象となっているかどうか（調査済みかどうか）
}



public class AStarPath : MonoBehaviour
{
    public Tilemap map;                     // 移動範囲
    public TileBase replaceTile;            // 移動線上に位置するタイルの色を代える
    public GameObject goalObject;           // 目的地のゲームオブジェクト
    public GameObject startObject;          // 開始地点のゲームオブジェクト
    private List<cellInfo> cellInfoList;    // 調査セルを記憶しておくリスト
    private Stack<cellInfo> pathInfo;       // 最短経路情報のみを記憶しておくスタック（上から積み重ねて保存し、上から取り出すイメージ）
    private Vector3 goal;                   // ゴールの位置情報
    private bool exitFlg;                   // 処理が終了したかどうかのフラグ

    void Start()
    {
        cellInfoList = new List<cellInfo>();//リスト生成

        astarSearchPathFinding();//実際に計算
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //マウス入力からワールド座標を取得
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //ワールド座標からタイルマップでの座標を取得
            Vector3Int grid = map.WorldToCell(mouse_position);
            Debug.Log(grid);
        }
    }

    /// <summary> AStarアルゴリズムです。 </summary>
    public void astarSearchPathFinding()
    {
        // ゴールはプレイヤーの位置情報
        goal = goalObject.transform.position;

        // スタートの情報を設定する(スタートは敵)
        cellInfo start = new cellInfo();//スタート地点情報を保存するための変数を作る
        start.pos = startObject.transform.position;
        start.cost = 0;                                                          //何歩歩いたか
        start.heuristic = Vector2.Distance(startObject.transform.position, goal);//ゴール地点との実距離
        start.sumConst = start.cost + start.heuristic;
        start.parent = new Vector3(-9999, -9999, 0);    // スタート時の親の位置はありえない値にしておきます。最後に色を付けるときに使用する
        start.isOpen = true;                            // 調査が終わっていない
        cellInfoList.Add(start);                        // リストに追加

        exitFlg = false;//全体としては調査は終わっていない

        // （中心のノードに）オープンが存在する限りループ(始めはスタート地点。openSurroundでリストに追加されていく)
        while (cellInfoList.Where(x => x.isOpen == true).Select(x => x).Count() > 0 && exitFlg == false)
        {
            //「総コスト = 実コスト + 推定コスト」が 最小のコストのノードを探す
            cellInfo minCell = cellInfoList.Where(x => x.isOpen == true).OrderBy(x => x.sumConst).Select(x => x).First();

           // Debug.Log(map.WorldToCell(minCell.pos));

            openSurround(minCell);//周辺のセルを探る（調査が終わっていないところ限定）

            // 中心のノードを閉じる
            minCell.isOpen = false;
        }
    }

    /// <summary> 周辺のセル（最小コストのセル）を探る　 </summary>
    private void openSurround(cellInfo center)
    {
        // ポジションをVector3Intへ変換
        Vector3Int centerPos = map.WorldToCell(center.pos);//ワールド座標をマップ座標に変換

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                // 上下左右のみ可とする、かつ、中心は除外
                if (((i != 0 && j == 0) || (i == 0 && j != 0)) && !(i == 0 && j == 0))
                {
                    Vector3Int posInt = new Vector3Int(centerPos.x + i, centerPos.y + j, centerPos.z);
                    if (map.HasTile(posInt) && !(i == 0 && j == 0))//タイルがあってなおかつ自分は含めない
                    {
                        Vector3 pos = map.CellToWorld(posInt);
                        pos = new Vector3(pos.x + 0.5f, pos.y + 0.5f, pos.z);

                        // リストに存在しないなら（該当情報がリストの中にないなら）新しく探索する場所として登録
                        if (cellInfoList.Where(x => x.pos == pos).Select(x => x).Count() == 0)//一致するワールド座標がないなら
                        {                            
                            cellInfo cell = new cellInfo();
                            cell.pos = pos;
                            cell.cost = center.cost + 1;
                            cell.heuristic = Vector2.Distance(pos, goal);
                            cell.sumConst = cell.cost + cell.heuristic;//あとでこのコストの最小ものが参照され処理が行われる
                            cell.parent = center.pos;//親に設定
                            cell.isOpen = true;

                            cellInfoList.Add(cell);// リストに追加

                            // ゴール位置のマップ座標と一致したら終了
                            if (map.WorldToCell(goal) == map.WorldToCell(pos))
                            {
                                cellInfo preCell = cell;//最終的なセル情報

                                while (preCell.parent != new Vector3(-9999, -9999, 0))//ゴールから色を塗っていく。スタート地点に戻るまで
                                {   
                                    map.SetTile(map.WorldToCell(preCell.pos), replaceTile);//該当セルを上書きする
                                    preCell = cellInfoList.Where(x => x.pos == preCell.parent).Select(x => x).First();//ゴールのセルから逆算していく。セルの親をたどる
                                }

                                exitFlg = true;//終了フラグオン
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}