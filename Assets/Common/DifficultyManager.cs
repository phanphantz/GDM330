using DG.Tweening;
using PhEngine.Core;
using UnityEngine;

namespace SuperGame
{
    public class DifficultyManager : Singleton<DifficultyManager>
    {
        public int DifficultyLevel => difficultyLevel;
        [SerializeField] int difficultyLevel;
        [SerializeField] CanvasGroup difficultyUI;
        
        protected override void InitAfterAwake()
        {
            difficultyUI.gameObject.SetActive(true);
            difficultyUI.alpha = 0;
            difficultyUI.blocksRaycasts = false;
            difficultyUI
                .DOFade(1f, 1f)
                .OnComplete(FadeInFinish)
                .SetUpdate(true);
        }

        void FadeInFinish()
        {
            difficultyUI.blocksRaycasts = true;
        }

        public void SelectDifficultyLevel(int value)
        {
            difficultyLevel = value;
            difficultyUI.blocksRaycasts = false;
            difficultyUI
                .DOFade(0, 1f)
                .OnComplete(FadeOutFinish)
                .SetUpdate(true);
        }

        void FadeOutFinish()
        {
            GameManager.Instance.StartLevel();
            difficultyUI.gameObject.SetActive(false);
        }
    }
}