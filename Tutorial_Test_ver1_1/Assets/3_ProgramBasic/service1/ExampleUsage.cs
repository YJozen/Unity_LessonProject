using Scenes.Common;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    void Start()
    {
        // スコアの設定
        SamplePlayerPrefs.Score = 42;

        // スコアの取得
        int score = SamplePlayerPrefs.Score;
        Debug.Log($"Current Score: {score}");
    }
}