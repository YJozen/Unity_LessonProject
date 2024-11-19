using UnityEngine;

namespace Services2{

    public class AudioService : IAudioService {
        public void PlaySound(string soundName) {
            Debug.Log("Playing sound: " + soundName);
            // 実際のサウンド再生ロジックを書く

        }
    }

}
