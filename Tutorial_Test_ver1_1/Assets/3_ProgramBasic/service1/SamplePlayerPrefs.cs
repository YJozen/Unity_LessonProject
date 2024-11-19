using Services;
using UnityEngine;


namespace Scenes.Common
{
    /// <summary>
    /// PlayerPrefs管理クラス
    /// </summary>
    public static class SamplePlayerPrefs
    {
        /// <summary>
        /// スコア
        /// </summary>
        public static int Score
        {
            get => GetPlayerPrefsIntValue(KeyScore);
            set => SetPlayerPrefsIntValue(KeyScore, value);
        }
        private const string KeyScore = "Score";
        
        private static void SetPlayerPrefsIntValue(string key, int value)
        {
            ServiceLocator.Resolve<IPlayerPrefsService>().SetInt(key, value);
        }

        private static int GetPlayerPrefsIntValue(string key)
        {
            return ServiceLocator.Resolve<IPlayerPrefsService>().GetInt(key);
        }
    }
}
