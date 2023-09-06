using UnityEngine;

namespace SuperGame.SubwaySurfer2D
{
    public class PlayerTakeDamage : MonoBehaviour
    {
        [SerializeField] int damage = 1;
      
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                var player = collision.gameObject.GetComponent<Player>();
                player.Health.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
