using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrefabRef
{
    public class InstantinatePrefab : MonoBehaviour
    {
        [SerializeField]GameObject prefabObject;

        [SerializeField]HierarchyObject hierarchyObject;

        float interval = 3f ;

        void Start()
        {
            InvokeRepeating("StartInstantPrefab", 0, interval);
        }

        void StartInstantPrefab()
        {
            StartCoroutine(InstantPrefab());
        }


        IEnumerator InstantPrefab()
        {
            Vector3 generatePos = new Vector3(0f,Random.Range(-1,1),0f);

            GameObject gObject = Instantiate(prefabObject, generatePos,Quaternion.identity);

            PrefabObject pObject = gObject.GetComponent<PrefabObject>();
            //pObject.SetHierarchyObject(GameObject.Find("HierarchyObject").GetComponent<HierarchyObject>());
            pObject.SetHierarchyObject(hierarchyObject);

            yield return new WaitForSeconds(interval);

            Destroy(gObject);
        }

    }
}