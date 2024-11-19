using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NavMesh_Sample {
    public class CharacterNavigation : MonoBehaviour
    {
        [SerializeField] private Transform m_Target;

        private UnityEngine.AI.NavMeshAgent m_Agent;


        Rigidbody rb;

        [SerializeField] bool istopped;


        void Start() {
            m_Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            // rb=GetComponent<Rigidbody>();
            // m_Agent.enabled = false;
        }

        void Update() {
            m_Agent.SetDestination(m_Target.position);
            m_Agent.isStopped = istopped;
            // m_Agent.enabled 
            // rb.AddForce(transform.forward*10f);
        }
    }
}

