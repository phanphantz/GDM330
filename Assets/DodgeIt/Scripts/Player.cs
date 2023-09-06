using UnityEngine;

namespace SuperGame.DodgeIt
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rigidbody;
        
        public Health Health => health;
        [SerializeField] Health health;
        
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float jumpForce = 2f;

        // Update is called once per frame
        void Update()
        {
            if (health.CurrentHealth <= 0)
                return;

            var horizontalInput = InputManager.Instance.HorizontalInput;
            var moveDirection = horizontalInput * new Vector3(1, 0, 0);
            rigidbody.AddForce(moveDirection * moveSpeed);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "GameOver")
            {
                GameManager.Instance.Lose();
            }
        }
    }
}
