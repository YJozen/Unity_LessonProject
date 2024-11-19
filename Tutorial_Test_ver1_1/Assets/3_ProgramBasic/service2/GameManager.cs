using UnityEngine;

namespace Services2{
    public class GameManager : MonoBehaviour {
    void Start() {
        // サービスの登録
        ServiceLocator.RegisterService<IAudioService>(new AudioService());

        // サービスの取得と使用
        var audioService = ServiceLocator.GetService<IAudioService>();
        audioService.PlaySound("BackgroundMusic");
    }
}
}
