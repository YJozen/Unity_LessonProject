using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MirrorCameraSample {
    public class MirrorCamera : MonoBehaviour
    {
        ReflectionProbe probe;

        void Start()
        {
            this.probe = GetComponent<ReflectionProbe>();
        }

        void Update()
        {

            //yŽ²‚Í-1‚ð‚©‚¯‚Ä‹t‘¤‚É”z’u‚·‚é
            this.probe.transform.position = new Vector3(Camera.main.transform.position.x,
                                                        Camera.main.transform.position.y * -1,
                                                        Camera.main.transform.position.z);

            probe.RenderProbe();
        }

        private void FixedUpdate()
        {

        }

    }
}

