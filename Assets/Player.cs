using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] int currentHealth = 5;
    [SerializeField] GameObject gameOverObj;
    [SerializeField] TMP_Text currentHealthText;
    
    // Start is called before the first frame update
    void Start()
    {
        RefreshHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            return;
        
        var horizontalInput = Input.GetAxis("Horizontal");
        var moveDirection = horizontalInput * new Vector3(1, 0, 0);
        rigidbody.AddForce(moveDirection * moveSpeed);
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0)
            return;

        currentHealth--;
        if (currentHealth == 0)
        {
            gameOverObj.SetActive(true);
        }

        RefreshHealth();
    }

    void RefreshHealth()
    {
        currentHealthText.text = "Health : " + currentHealth;
    }
}
