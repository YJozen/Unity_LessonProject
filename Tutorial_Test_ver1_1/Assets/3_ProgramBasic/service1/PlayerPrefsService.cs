using UnityEngine;

namespace Services
{
    public class PlayerPrefsService : IPlayerPrefsService
    {
        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
    }
}
