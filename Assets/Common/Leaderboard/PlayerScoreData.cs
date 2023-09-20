using UnityEngine;

namespace SuperGame.Leaderboard
{
    [CreateAssetMenu(menuName = "SuperGame/PlayerScoreData" , fileName = "PlayerScoreData")]
    public class PlayerScoreData : ScriptableObject
    {
        public string username;
        public int order;
        public int score;
        public int star;
    }
}