using UnityEngine;

namespace SuperGame
{
    public abstract class UIHealth : MonoBehaviour
    {
        public abstract void SetHealth(int currentHealth, int maxHealth);
    }
}