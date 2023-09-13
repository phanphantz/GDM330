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

            var duration = 0.4f;
            damageText.enabled = true;
            damageText.color = Color.clear;
            damageText.DOColor(Color.red, duration);
            damageText.transform.DOScale(Vector3.one, duration);
            damageText.transform.DOLocalMoveY(originalPosition.y + 50f, duration);
        }

        
    }
}