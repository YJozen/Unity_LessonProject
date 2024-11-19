using UnityEngine;

[ExecuteAlways] // 再生していない間も座標と半径が変化するように
public class SlimeRenderer2 : MonoBehaviour
{
    [SerializeField] private Material material; // スライム用のマテリアル

    private const int MaxSphereCount = 256; // 球の最大個数（シェーダー側と合わせる）
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    private SphereCollider[] _colliders;

    private Vector4[] _colors = new Vector4[MaxSphereCount];//シェーダーに追加した _Colors に値を格納するためのC#コードを追加します。

    private void Start()
    {     
        _colliders = GetComponentsInChildren<SphereCollider>();// 子のSphereColliderをすべて取得   
        material.SetInt("_SphereCount", _colliders.Length);    // シェーダー側の _SphereCount を更新　球の数

        // ランダムな色を配列に格納
        for (var i = 0; i < _colors.Length; i++)                   {
            _colors[i] = (Vector4)Random.ColorHSV(0, 1, 1, 1, 1, 1);
        }
        // シェーダー側の _Colors を更新
        material.SetVectorArray("_Colors", _colors);
    }

    private void Update()
    {
        // 子のSphereColliderの分だけ、_spheres に中心座標と半径を入れていく
        for (var i = 0; i < _colliders.Length; i++)
        {
            var col = _colliders[i];
            var t = col.transform;
            var center = t.position;
            var radius = t.lossyScale.x * col.radius;//半径　スケール＊コライダーの設定半径
           
            _spheres[i] = new Vector4(center.x, center.y, center.z, radius); // 中心座標と半径を格納
        }     
        material.SetVectorArray("_Spheres", _spheres);// シェーダー側の _Spheres 配列 を更新
    }
}
