using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace SuperGame
{
    public class UIRedCorners : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        Health health;
        
        void Awake()
        {
            health = FindObjectOfType<Health>();
            if (health != null)
                health.onTakeDamage += TakeDamage;
        }
        
        void OnDestroy()
        {
            health.onTakeDamage -= TakeDamage;
        }

        void TakeDamage(int value)
        {
            Debug.Log("Damage : " + value);
            Play();
        }

        public void Play()
        {
            var seq = DOTween.Sequence();
            seq.Append(canvasGroup.DOFade(1f, 0.5f));
            seq.Append(canvasGroup.DOFade(0, 1f));
        }
    }
}