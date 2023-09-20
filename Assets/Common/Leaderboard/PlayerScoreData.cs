using System;

namespace SuperGame.Leaderboard
{
    [Serializable]
    public class PlayerScoreData 
    {
        public string username;
        public string profileUrl;
        public int order;
        public int score;
        public int star;
    }
}