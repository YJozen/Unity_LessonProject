using System;

// カスタムイベントの引数として使用するクラス
public class MyEventArgs : EventArgs
{
    public string Message { get; }
    public int Value { get; }

    public MyEventArgs(string message, int value)
    {
        Message = message;
        Value = value;
    }
}