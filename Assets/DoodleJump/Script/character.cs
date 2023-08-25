using UnityEngine;

namespace SuperGame.DoodleJump
{
    public class character : MonoBehaviour
    {
        private Rigidbody2D rb;
    
        [SerializeField] float jumpforce = 100f;
        public float jumpboost = 2f;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
       
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "ground")
            { 
                rb.AddForce(Vector2.up*jumpforce);
            }
            if(other.gameObject.tag == "Superjump")
            { 
                rb.AddForce(Vector2.up*jumpforce*jumpboost);
            }
        }

    
    
    }
}
