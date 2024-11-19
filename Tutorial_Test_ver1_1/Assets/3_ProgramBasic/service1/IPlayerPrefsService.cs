
namespace Services
{
    /// <summary>
    /// PlayerPrefsService
    /// </summary>
    public interface IPlayerPrefsService
    {
        public void SetInt(string key, int value);
        public int GetInt(string key);
    }
}
