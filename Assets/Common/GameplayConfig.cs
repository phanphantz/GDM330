using UnityEngine;

namespace SuperGame
{
    [CreateAssetMenu(menuName = "SuperGame/GameplayConfig", fileName = "New Gameplay Config")]
    public class GameplayConfig : ScriptableObject
    {
        public int maxLifeCount = 3;
        public float timeScaleToAdd = 0.1f;
        public float countdownDuration = 10f;
    }
}