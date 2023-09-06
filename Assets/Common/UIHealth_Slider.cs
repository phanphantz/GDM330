using UnityEngine;
using UnityEngine.UI;

namespace SuperGame
{
    public class UIHealth_Slider : UIHealth
    {
        [SerializeField] Slider healthSlider;
        
        public override void SetHealth(int currentHealth, int maxHealth)
        {
            healthSlider.value = currentHealth / (float)maxHealth;
        }
    }
}