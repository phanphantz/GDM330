using UnityEngine;

namespace SuperGame
{
    public class Obstacle_ScreenMeme : Obstacle
    {
        [SerializeField] Animation animation;
        public override void Play()
        {
            var targetScale = Vector3.one * ( 1 + (DifficultyManager.Instance.DifficultyLevel));
            transform.localScale = targetScale;
            animation.Play();
        }
    }
}