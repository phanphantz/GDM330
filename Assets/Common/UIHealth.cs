using System;
using UnityEngine;

namespace SuperGame
{
    public abstract class UIHealth : MonoBehaviour
    {
        Health health;
        
        void Awake()
        {
            health = FindObjectOfType<Health>();
            if (health != null)
                health.onHealthChange += SetHealth;
        }

        void OnDestroy()
        {
            health.onHealthChange -= SetHealth;
        }

        public abstract void SetHealth(int currentHealth, int maxHealth);
    }
}