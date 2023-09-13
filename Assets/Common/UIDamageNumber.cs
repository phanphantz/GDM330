using System;
using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace SuperGame
{
    public class UIDamageNumber : MonoBehaviour
    {
        [SerializeField] TMP_Text damageText;

        Health health;

        Vector3 originalPosition;
        
        void Awake()
        {
            health = FindObjectOfType<Health>();
            if (health != null)
                health.onTakeDamage += SetDamage;
            
            originalPosition = damageText.transform.localPosition;
        }

        void OnDestroy()
        {
            health.onTakeDamage -= SetDamage;
        }

        public void SetDamage(int damage)
        {
            damageText.text = "-" + (damage * 10);
            damageText.transform.localPosition = originalPosition;
            damageText.transform.localScale = Vector3.zero;
            damageText.enabled = true;
            damageText.color = Color.clear;
            var duration = 0.4f;

            var seq = DOTween.Sequence();
            seq.Append(damageText.DOColor(Color.red, duration));
            seq.Join(damageText.transform.DOScale(Vector3.one, duration));

            //Delay
            seq.AppendInterval(0.5f);
            
            seq.Append(damageText.transform.DOLocalMoveY(originalPosition.y + 500f, duration));
            seq.Join(damageText.transform.DOScale(0f, duration));

            //Call a function
            seq.AppendCallback(PlaySound);

            // seq.SetLoops(2, LoopType.Yoyo);
            //seq.SetEase(Ease.InSine);
        }

        void PlaySound()
        {
            AudioManager.Instance.PlayOneShot("hurt");
        }
    }
}