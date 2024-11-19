namespace SampleGame1
{
    [System.Serializable]
    public class PlayerSaveData
    {
        public string name;
        public int score;


        public PlayerSaveData(string name ,int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}