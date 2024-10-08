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

        string scaleAnimationId = "scaleAnimation";
        
        protected override void InitAfterAwake()
        {
            difficultyUI.gameObject.SetActive(true);
            difficultyUI.alpha = 0;
            difficultyUI.blocksRaycasts = false;
            difficultyUI
                .DOFade(1f, 1f)
                .OnComplete(FadeInFinish)
                .SetUpdate(true);

            difficultyUI.transform
                .DOScale(0.7f, 1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetUpdate(true)
                .SetId(scaleAnimationId);
        }

        void FadeInFinish()
        {
            difficultyUI.blocksRaycasts = true;
        }

        public void SelectDifficultyLevel(int value)
        {
            DOTween.Kill(scaleAnimationId, true);
            
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