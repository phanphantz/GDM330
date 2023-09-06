using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame.FlappyBird
{
    public class Movement : MonoBehaviour
    {
        public Gameloop gameLoop;
        public Rigidbody2D myRigidbody2D;
        public Animator animator;
        public float jumpForce;

        public bool isDead = false;

        // Update is called once per frame
        void Update()
        {
            SetIsIdle(true);
            if (!isDead)
            {
                if (InputManager.Instance.IsJump && gameLoop.GameIsRunning)
                {
                    //Debug.Log("jump");
                    myRigidbody2D.velocity = new Vector2(0, 0);
                    myRigidbody2D.AddForce(jumpForce * Vector2.up);
                    AudioManager.Instance.Play("jump");
                    animator.SetTrigger("Jump");
                }
            }
            else
            {
                animator.SetBool("die", true);
                SetIsIdle(false);
            }
        }

        void SetIsIdle(bool value)
        {
            animator.SetBool("idle", value);
        }
    }
}