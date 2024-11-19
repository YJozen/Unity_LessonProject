using UnityEngine;

public class TriggerEventExample : MonoBehaviour
{
    [SerializeField] private Publisher publisher;  // Publisherの参照

    void Update()
    {
        // スペースキーが押されたらイベントを発火
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 引数としてメッセージと数値を渡す
            publisher.TriggerEvent("スペースキーが押されました", 42);
        }
    }
}
