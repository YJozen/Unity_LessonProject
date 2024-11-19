//https://github.com/ClaytonIndustries/QuickSave/wiki

using UnityEngine;
using CI.QuickSave;
using CI.QuickSave.Core.Storage;

namespace QuickSave_Sample
{
    public class UserData
    {
        //ユーザー名
        string userName ;

        //ベストスコア
        int bestScore;

        //セーブ設定
        static QuickSaveSettings m_saveSettings;

        public void Start() {
            // QuickSaveSettingsのインスタンスを作成
            m_saveSettings = new QuickSaveSettings();
            // 暗号化の方法 
            m_saveSettings.SecurityMode = SecurityMode.Aes;
            // Aesの暗号化キー
            m_saveSettings.Password = "Password";
            // 圧縮の方法
            m_saveSettings.CompressionMode = CompressionMode.Gzip;
        }
        

        /// <summary>セーブデータ読み込み</summary>r
        public void LoadUserData() {
            //ファイルが無ければ無視
            if (FileAccess.Exists("SaveData", false) == false) {
                return;
            }

            // QuickSaveReaderのインスタンスを作成
            QuickSaveReader reader = QuickSaveReader.Create("SaveData", m_saveSettings);

            // データを読み込む
            userName = reader.Read<string>("UserName");
            bestScore = reader.Read<int>("BestScore");

            Debug.Log($"UserName : {userName} , BestScore : {bestScore}");
        }

        /// <summary>データセーブ</summary>w
        public void SaveUserData(string userName, int bestScore) {
            Debug.Log("セーブデータ保存先:" + Application.persistentDataPath);            
            QuickSaveWriter writer = QuickSaveWriter.Create("SaveData", m_saveSettings);// QuickSaveWriterのインスタンスを作成

            Debug.Log("データを書き込む");
            // データを書き込む
            writer.Write("UserName", userName);
            writer.Write("BestScore", bestScore);

            // 変更を反映
            writer.Commit();
        }
    }
}

