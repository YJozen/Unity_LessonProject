using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ref_Sample
{
    public class Ref1 : MonoBehaviour
    {
        int Damage = 1;

        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.TryGetComponent<Ref2>(out Ref2 ref2))
            {
                ref2.TakeDamage(Damage);
                Debug.Log($"Ref1からRef2を参照 {ref2.Hp}");
            }
        }
    } 
}

