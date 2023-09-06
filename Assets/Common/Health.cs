using System;
using TMPro;
using UnityEngine;

namespace SuperGame
{
    public class Health : MonoBehaviour
    {
        [SerializeField] string hurtSoundId = "hurt";

        public int CurrentHealth => currentHealth;
        [SerializeField] int currentHealth = 5;
        
        [SerializeField] SpriteRenderer renderer;
        [SerializeField] TMP_Text currentHealthText;

        void Start()
        {
            RefreshHealth();
        }

        public void TakeDamage()
        {
            if (currentHealth <= 0)
                return;

            currentHealth--;
            AudioManager.Instance.Play(hurtSoundId);
            DamageEffectPlayer.Instance.PlayOn(renderer);
            RefreshHealth();
        }

        public void RefreshHealth()
        {
            currentHealthText.text = "Health : " + currentHealth;
        }
    }
}