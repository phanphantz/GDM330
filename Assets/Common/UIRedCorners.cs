using System.Collections;
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
            StartCoroutine(AnimationRoutine());
        }

        IEnumerator AnimationRoutine()
        {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(1f);
            canvasGroup.alpha = 0;
        }
    }
}