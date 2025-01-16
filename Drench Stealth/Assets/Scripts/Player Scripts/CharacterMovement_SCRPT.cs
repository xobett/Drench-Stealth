using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement_SCRPT : MonoBehaviour
{
    [Header("Player Movement")]
    private Rigidbody2D characterRb;

    public float hor;

    public bool moving;


    [Header("Player Jump")]

    private Transform groundCheck;

    public LayerMask groundLayer;
    public LayerMask cloudLayer;
    
    public float radius;
    public float speed;
    public float jumpForce;

    public bool touching;

    #region Player Animator and Flip

    private Animator animator;

    private bool facingRight;
    private bool isMovingAnimator;

    private AudioManager audioManager;

    #endregion

    private void Start()
    {
        Application.targetFrameRate = 60;

        characterRb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        groundCheck = transform.GetChild(0);

        moving = true;

        facingRight = true;
    }

    private void Update()
    {
        GroundCheck();

        Jump();

        AnimatorBools();

        FlipCheck();
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            hor = Input.GetAxis("Horizontal");

            transform.Translate(hor * speed * Time.deltaTime, 0, 0);
        }
    }

    private void GroundCheck()
    {

        if (Physics2D.OverlapCircle(groundCheck.transform.position, radius, groundLayer) || Physics2D.OverlapCircle(groundCheck.transform.position, radius, cloudLayer))
        {
            touching = true;
        }
        else
        {
            touching = false;
        }

        animator.SetBool("isTouching", touching);
    }

    private void Jump()
    {
        if (moving)
        {
            if (Input.GetButtonDown("Jump") && touching)
            {
                characterRb.AddForce(transform.up * jumpForce);

                audioManager.PlaySfx(audioManager.jump);
            }
        }
    }

    private void AnimatorBools()
    {
        if (hor != 0)
        {
            isMovingAnimator = true;
        }
        else
        {
            isMovingAnimator = false;
        }

        animator.SetBool("isMoving", isMovingAnimator);
    }

    private void FlipCheck()
    {
        if (facingRight && hor < 0 || !facingRight && hor > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }
}
