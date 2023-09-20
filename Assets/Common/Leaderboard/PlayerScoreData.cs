using System;
using UnityEngine;

namespace SuperGame.Leaderboard
{
    [Serializable]
    public class PlayerScoreData 
    {
        public string username;
        public int order;
        public int score;
        public int star;
    }
}