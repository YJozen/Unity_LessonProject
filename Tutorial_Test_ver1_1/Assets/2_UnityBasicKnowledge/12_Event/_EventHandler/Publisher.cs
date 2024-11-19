using System;
using UnityEngine;

public class Publisher : MonoBehaviour
{
    // EventHandlerを使用したイベント定義
    public event EventHandler<MyEventArgs> MyEvent;

    // イベントを発火するメソッド
    public void TriggerEvent(string message, int value)
    {
        // イベントが登録されていればInvokeで発火
        MyEvent?.Invoke(this, new MyEventArgs(message, value));
    }
}