using System.Collections;
using TMPro;
using UnityEngine;
using SuperGame.FlappyBird;
using UnityEngine.UI;

namespace SuperGame
{
    public class Health : MonoBehaviour
    {
        [SerializeField] string hurtSoundId = "hurt";
        [SerializeField] int maxHealth = 5;
        [SerializeField] float immunityDuration = 2.0f;

        public int CurrentHealth => currentHealth;
        [SerializeField] int currentHealth = 5;
        
        [SerializeField] SpriteRenderer renderer;

        [Header("UI")] 
        [SerializeField] UIHealth ui;
        
        [Header("Flappy Bird Only")]
        [SerializeField] Movement movement;
        
        bool isImmune; // สถานะอมตะ

        void Start()
        {
            currentHealth = maxHealth;
            RefreshHealth();
        }

        public void TakeDamage(int damage)
        {
            if (currentHealth <= 0 || isImmune)
                return;

            currentHealth -= damage;
            AudioManager.Instance.Play(hurtSoundId);
            DamageEffectPlayer.Instance.PlayOn(renderer);
            RefreshHealth();
            if (currentHealth <= 0)
            {
                GameManager.Instance.Lose();
                if (movement != null)
                    movement.isDead = true;
            }
            else
            {
                StartCoroutine(ApplyImmunity());
            }
        }

        void RefreshHealth()
        {
           ui.SetHealth(currentHealth, maxHealth);
        }
        
        IEnumerator ApplyImmunity()
        {
            isImmune = true; // เริ่มสถานะอมตะ
            Debug.Log("Immunity");
            yield return new WaitForSeconds(immunityDuration); // รอเวลาอมตะ
            isImmune = false; // สิ้นสถานะอมตะ
        }
    }
}