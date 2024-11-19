using UnityEngine;

[ExecuteAlways] // 再生していない間も座標と半径が変化するように
public class SlimeRenderer1 : MonoBehaviour
{
    [SerializeField] private Material material; // スライム用のマテリアル

    private const int MaxSphereCount = 256; // 球の最大個数（シェーダー側と合わせる）
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    private SphereCollider[] _colliders;

    private void Start()
    {     
        _colliders = GetComponentsInChildren<SphereCollider>();// 子のSphereColliderをすべて取得   
        material.SetInt("_SphereCount", _colliders.Length);    // シェーダー側の _SphereCount を更新　球の数
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
