using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string Id;
    public int Hp;
    public int Attack;
    public int Defense;
    public int Exp;
}

[CreateAssetMenu(menuName = "ScriptableObject/Enemy Setting", fileName = "EnemySetting")]
public class EnemySetting : ScriptableObject
{
    public List<EnemyData> DataList;
}


//ScriptableObject用のクラスは以下の設定が必要です。

//ScriptableObjectを継承する
//CreateAssetMenuアトリビュートをクラスに持たせる