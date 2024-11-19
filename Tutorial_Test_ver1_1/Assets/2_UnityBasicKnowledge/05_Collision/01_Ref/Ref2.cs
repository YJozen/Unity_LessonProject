using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ref_Sample
{
    public class Ref2 : MonoBehaviour
    {
        public int Hp { get; private set; } = 50;

        // HPを直接設定するメソッド
        public void SetHp(int hp)
        {
            Hp = hp;
        }

        public void TakeDamage(int damage)
        {
            Hp = Mathf.Max(Hp - damage, 0); // HPが0未満にならないようにする
        }
    } 
}

