using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float movespeed = 12f;
    float horizontalMove = 0f;
    bool jump = false;
    Rigidbody2D rb;
    public Animator animator;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") *movespeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //passes horiziontal movement, something, and whether or not we are jumping
        jump = false;
        
    }

    private void Flip()
    {

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
