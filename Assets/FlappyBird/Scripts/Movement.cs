using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        animator.SetBool("idle", true);
        if (!isDead)
        {
            if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))&&gameLoop.GameIsRunning)
            {
                //Debug.Log("jump");
                myRigidbody2D.velocity = new Vector2(0, 0);
                myRigidbody2D.AddForce(jumpForce * Vector2.up);
                animator.SetTrigger("Jump");
            }            
        }
        else
        {
            animator.SetBool("die", true);
            animator.SetBool("idle", false);
        }
    }
}
