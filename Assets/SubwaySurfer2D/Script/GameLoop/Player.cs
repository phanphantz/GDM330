using SuperGame.SubwaySurfer2D;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperGame.SubwaySurfer2D
{
    public class Player : MonoBehaviour
    {
        [SerializeField] int defaultDamage = 1;
        [SerializeField] PlayerMovement move;
        [SerializeField] SpriteRenderer renderer;

        public Health Health => health;
        [SerializeField] Health health;
        
        public int coinScore = 0;
        public TMP_Text scoreText;
        // Start is called before the first frame update
        void Start()
        {
            CoinScoreUI();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Train")
            {
                Vector2 collisionDirection = other.transform.position - transform.position;

                if (Mathf.Abs(collisionDirection.x) > Mathf.Abs(collisionDirection.y))
                {
                    if(move.currentLine == 1 || move.currentLine == -1) 
                    {
                        move.targetPosition = move.targetmiddle.position;
                        move.currentLine= 0;
                    }

                    else if(move.left == true && move.currentLine == 0)
                    {
                        move.left = false;
                        move.targetPosition = move.targetleft.position;
                        move.currentLine = -1; 
                    }

                    else if(move.right == true && move.currentLine == 0)
                    {
                        move.right = false;
                        move.targetPosition = move.targetright.position;
                        move.currentLine = 1;
                    }
                    
                    health.TakeDamage(defaultDamage);
                }
                else
                {
                    GameManager.Instance.Lose();
                }
            }
        }
        
        public void GetCoins()
        {
            coinScore = coinScore + 5;
            AudioManager.Instance.Play("coin");
            CoinScoreUI();
        }

        void CoinScoreUI()
        {
            scoreText.text = "Coin :" + coinScore;
        }
    }
}
