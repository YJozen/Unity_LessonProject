using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloorMove_Sample
{
    public class FloorMove : MonoBehaviour
    {
        int counter = 0;
        float move = 0.01f;

        void Update() {
            transform.Translate(new Vector3(move, 0, 0));

            counter++;
            if (counter == 300) {
                counter = 0;
                move *= -1;
            }
        }
    }
}
