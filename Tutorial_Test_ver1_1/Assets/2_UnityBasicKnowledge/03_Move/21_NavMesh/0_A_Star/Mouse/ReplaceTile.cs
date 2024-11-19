using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReplaceTile : MonoBehaviour
{
    public TileBase m_tileChange;
    public Tilemap m_tilemap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //マウス入力からワールド座標を取得
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //ワールド座標からタイルマップでの座標を取得
            Vector3Int grid = m_tilemap.WorldToCell(mouse_position);
            Debug.Log(grid);

            //タイルマップ上にタイルがあれば
            if (m_tilemap.HasTile(grid))
            {
                //タイルマップを上書きする
                m_tilemap.SetTile(grid, m_tileChange);
            }
        }
    }
}