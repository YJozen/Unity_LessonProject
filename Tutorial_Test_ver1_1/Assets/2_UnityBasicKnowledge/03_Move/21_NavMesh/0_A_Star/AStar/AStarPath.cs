using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class cellInfo
{
    public Vector3 pos { get; set; }        // �Ώۂ̈ʒu���(�^�C����pivot)
    public float cost { get; set; }         // ���R�X�g(���܂ŉ�����������)
    public float heuristic { get; set; }    // ����R�X�g(�S�[���܂ł̋���)
    public float sumConst { get; set; }     // ���R�X�g = ���R�X�g + ����R�X�g
    public Vector3 parent { get; set; }     // �e�Z���̈ʒu���(�e�����ɂ�����X�^�[�g�n�_)
    public bool isOpen { get; set; }        // �����ΏۂƂȂ��Ă��邩�ǂ����i�����ς݂��ǂ����j
}



public class AStarPath : MonoBehaviour
{
    public Tilemap map;                     // �ړ��͈�
    public TileBase replaceTile;            // �ړ�����Ɉʒu����^�C���̐F��ウ��
    public GameObject goalObject;           // �ړI�n�̃Q�[���I�u�W�F�N�g
    public GameObject startObject;          // �J�n�n�_�̃Q�[���I�u�W�F�N�g
    private List<cellInfo> cellInfoList;    // �����Z�����L�����Ă������X�g
    private Stack<cellInfo> pathInfo;       // �ŒZ�o�H���݂̂��L�����Ă����X�^�b�N�i�ォ��ςݏd�˂ĕۑ����A�ォ����o���C���[�W�j
    private Vector3 goal;                   // �S�[���̈ʒu���
    private bool exitFlg;                   // �������I���������ǂ����̃t���O

    void Start()
    {
        cellInfoList = new List<cellInfo>();//���X�g����

        astarSearchPathFinding();//���ۂɌv�Z
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X���͂��烏�[���h���W���擾
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //���[���h���W����^�C���}�b�v�ł̍��W���擾
            Vector3Int grid = map.WorldToCell(mouse_position);
            Debug.Log(grid);
        }
    }

    /// <summary> AStar�A���S���Y���ł��B </summary>
    public void astarSearchPathFinding()
    {
        // �S�[���̓v���C���[�̈ʒu���
        goal = goalObject.transform.position;

        // �X�^�[�g�̏���ݒ肷��(�X�^�[�g�͓G)
        cellInfo start = new cellInfo();//�X�^�[�g�n�_����ۑ����邽�߂̕ϐ������
        start.pos = startObject.transform.position;
        start.cost = 0;                                                          //������������
        start.heuristic = Vector2.Distance(startObject.transform.position, goal);//�S�[���n�_�Ƃ̎�����
        start.sumConst = start.cost + start.heuristic;
        start.parent = new Vector3(-9999, -9999, 0);    // �X�^�[�g���̐e�̈ʒu�͂��肦�Ȃ��l�ɂ��Ă����܂��B�Ō�ɐF��t����Ƃ��Ɏg�p����
        start.isOpen = true;                            // �������I����Ă��Ȃ�
        cellInfoList.Add(start);                        // ���X�g�ɒǉ�

        exitFlg = false;//�S�̂Ƃ��Ă͒����͏I����Ă��Ȃ�

        // �i���S�̃m�[�h�Ɂj�I�[�v�������݂�����胋�[�v(�n�߂̓X�^�[�g�n�_�BopenSurround�Ń��X�g�ɒǉ�����Ă���)
        while (cellInfoList.Where(x => x.isOpen == true).Select(x => x).Count() > 0 && exitFlg == false)
        {
            //�u���R�X�g = ���R�X�g + ����R�X�g�v�� �ŏ��̃R�X�g�̃m�[�h��T��
            cellInfo minCell = cellInfoList.Where(x => x.isOpen == true).OrderBy(x => x.sumConst).Select(x => x).First();

           // Debug.Log(map.WorldToCell(minCell.pos));

            openSurround(minCell);//���ӂ̃Z����T��i�������I����Ă��Ȃ��Ƃ������j

            // ���S�̃m�[�h�����
            minCell.isOpen = false;
        }
    }

    /// <summary> ���ӂ̃Z���i�ŏ��R�X�g�̃Z���j��T��@ </summary>
    private void openSurround(cellInfo center)
    {
        // �|�W�V������Vector3Int�֕ϊ�
        Vector3Int centerPos = map.WorldToCell(center.pos);//���[���h���W���}�b�v���W�ɕϊ�

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                // �㉺���E�̂݉Ƃ���A���A���S�͏��O
                if (((i != 0 && j == 0) || (i == 0 && j != 0)) && !(i == 0 && j == 0))
                {
                    Vector3Int posInt = new Vector3Int(centerPos.x + i, centerPos.y + j, centerPos.z);
                    if (map.HasTile(posInt) && !(i == 0 && j == 0))//�^�C���������ĂȂ��������͊܂߂Ȃ�
                    {
                        Vector3 pos = map.CellToWorld(posInt);
                        pos = new Vector3(pos.x + 0.5f, pos.y + 0.5f, pos.z);

                        // ���X�g�ɑ��݂��Ȃ��Ȃ�i�Y����񂪃��X�g�̒��ɂȂ��Ȃ�j�V�����T������ꏊ�Ƃ��ēo�^
                        if (cellInfoList.Where(x => x.pos == pos).Select(x => x).Count() == 0)//��v���郏�[���h���W���Ȃ��Ȃ�
                        {                            
                            cellInfo cell = new cellInfo();
                            cell.pos = pos;
                            cell.cost = center.cost + 1;
                            cell.heuristic = Vector2.Distance(pos, goal);
                            cell.sumConst = cell.cost + cell.heuristic;//���Ƃł��̃R�X�g�̍ŏ����̂��Q�Ƃ��ꏈ�����s����
                            cell.parent = center.pos;//�e�ɐݒ�
                            cell.isOpen = true;

                            cellInfoList.Add(cell);// ���X�g�ɒǉ�

                            // �S�[���ʒu�̃}�b�v���W�ƈ�v������I��
                            if (map.WorldToCell(goal) == map.WorldToCell(pos))
                            {
                                cellInfo preCell = cell;//�ŏI�I�ȃZ�����

                                while (preCell.parent != new Vector3(-9999, -9999, 0))//�S�[������F��h���Ă����B�X�^�[�g�n�_�ɖ߂�܂�
                                {   
                                    map.SetTile(map.WorldToCell(preCell.pos), replaceTile);//�Y���Z�����㏑������
                                    preCell = cellInfoList.Where(x => x.pos == preCell.parent).Select(x => x).First();//�S�[���̃Z������t�Z���Ă����B�Z���̐e�����ǂ�
                                }

                                exitFlg = true;//�I���t���O�I��
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}