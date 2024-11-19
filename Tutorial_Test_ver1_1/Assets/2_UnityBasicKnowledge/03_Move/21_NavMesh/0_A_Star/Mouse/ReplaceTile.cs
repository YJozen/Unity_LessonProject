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
            //�}�E�X���͂��烏�[���h���W���擾
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //���[���h���W����^�C���}�b�v�ł̍��W���擾
            Vector3Int grid = m_tilemap.WorldToCell(mouse_position);
            Debug.Log(grid);

            //�^�C���}�b�v��Ƀ^�C���������
            if (m_tilemap.HasTile(grid))
            {
                //�^�C���}�b�v���㏑������
                m_tilemap.SetTile(grid, m_tileChange);
            }
        }
    }
}