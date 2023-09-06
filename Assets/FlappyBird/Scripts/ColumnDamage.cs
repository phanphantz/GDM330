using UnityEngine;

namespace SuperGame.FlappyBird
{
    public class ColumnDamage : MonoBehaviour
    {
        [SerializeField] int damage = 1;
        Health playerHealth;
        public float moveSpeed = 5f;

        void Start()
        {
            playerHealth = PlayerManager.Instance.GetPlayer().GetComponent<Health>();
        }

        void Update()
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Hit! Player takes 1 damage");
            }
        }
    }
}