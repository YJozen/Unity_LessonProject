using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneSample {
    public class SceneSample4 : MonoBehaviour
    {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.S)) {
                OnLoadSceneAdditive();
            }
        }
        public void OnLoadSceneAdditive() {
            //_4_Scene_Sample2を加算ロード。現在のシーンは残ったままで、_4_Scene_Sample2が追加される
            SceneManager.LoadScene("_4_Scene_Sample2", LoadSceneMode.Additive);
        }
    }
}

