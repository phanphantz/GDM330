using TMPro;
using UnityEngine;

namespace SuperGame
{
    public class UIHealth_Text : UIHealth
    {
        [SerializeField] TMP_Text currentHealthText;
        [SerializeField] string prefix = "Health : ";
        
        public override void SetHealth(int currentHealth, int maxHealth)
        {
            currentHealthText.text = prefix + currentHealth;
        }
    }
}