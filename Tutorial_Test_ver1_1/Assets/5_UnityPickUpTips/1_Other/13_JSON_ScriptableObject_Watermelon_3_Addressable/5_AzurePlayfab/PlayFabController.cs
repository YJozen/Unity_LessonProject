//参考サイト https://playfab-master.com/playfab-ranking

using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabController : MonoBehaviour
{
    void Start() {
        Login();//既存IDログイン
        //CreatePlayerAndUpdateDisplayName();//アカウント作成
    }
    public void SubmitScore(int playerScore) {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = playerScore
                }
            }
        }, result => {
            Debug.Log($"スコア {playerScore} 送信完了！");
        }, error => {
            Debug.Log(error.GenerateErrorReport());
        });
    }

    public void GetLeaderboard() {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest {
            StatisticName = "HighScore"
        }, result => {
            foreach (var item in result.Leaderboard) {
                Debug.Log($"{item.Position + 1}位:{item.DisplayName} " + $"スコア {item.StatValue}");
            }
        }, error => {
            Debug.Log(error.GenerateErrorReport());
        });
    }

    void UpdateDisplayName() {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest {
            DisplayName = "Sample-DisplayName"
        }, result => {
            Debug.Log("The player's display name is now: " + result.DisplayName);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void CreatePlayerAndUpdateDisplayName() {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest {
            CustomId      = "sample-custom-id",
            CreateAccount = true
        }, result => {
            Debug.Log("Successfully logged in a player with PlayFabId: " + result.PlayFabId);
            UpdateDisplayName();
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }


    void Login() {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest {
                TitleId = PlayFabSettings.TitleId,
                CustomId = "sample-custom-id",
                CreateAccount = false
            },
            result => {
                Debug.Log("ログイン成功！");

                SubmitScore(500);//スコア登録
                GetLeaderboard();//ランキング取得
            },
            error => {
                Debug.Log("ログイン失敗:" + error);
            }
        );
    }
}

