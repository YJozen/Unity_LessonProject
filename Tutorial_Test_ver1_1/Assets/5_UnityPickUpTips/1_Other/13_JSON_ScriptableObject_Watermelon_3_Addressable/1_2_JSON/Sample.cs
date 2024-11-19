using UnityEngine;

class Sample : MonoBehaviour { 
    void Start() {
        var SaveData = new SampleGame1.PlayerSaveData(string.Empty, 1);
        JsonSaveUtility.Save(SaveData);
    }       
    
} 