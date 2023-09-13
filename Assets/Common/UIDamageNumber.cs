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
            
            damageText.enabled = true;
            damageText.color = Color.clear;
            damageText.DOColor(Color.red, 1f);
            damageText.transform.DOLocalMoveY(originalPosition.y + 10f, 1f);
        }

        
    }
}