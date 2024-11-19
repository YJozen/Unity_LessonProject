using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private Publisher publisher;

    private void OnEnable()
    {
        // Publisherのイベントにメソッドを登録
        if (publisher != null)
        {
            publisher.MyEvent += OnEventReceived;
        }
    }

    private void OnDisable()
    {
        // イベントの登録を解除
        if (publisher != null)
        {
            publisher.MyEvent -= OnEventReceived;
        }
    }

    // イベントが発火されたときに呼び出されるメソッド
    private void OnEventReceived(object sender, MyEventArgs e)
    {
        // イベントの引数を利用してメッセージを表示
        Debug.Log($"イベントを受信しました: メッセージ = {e.Message}, 値 = {e.Value}");
    }
}