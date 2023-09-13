using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace SuperGame
{
    public class UIDamageNumber : MonoBehaviour
    {
        [SerializeField] TMP_Text damageText;

        void Awake()
        {
            var health = FindObjectOfType<Health>();
            health.onTakeDamage += SetDamage;
        }

        public void SetDamage(int damage)
        {
            damageText.text = "-" + (damage * 10);
            StartCoroutine(TextAnimation());
        }

        IEnumerator TextAnimation()
        {
            damageText.enabled = true;
            yield return new WaitForSeconds(1f);
            damageText.enabled = false;
        }
    }
}