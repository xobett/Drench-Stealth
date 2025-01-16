using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWater_SCRPT : MonoBehaviour
{
    #region Shoot Variables

    public GameObject puddle;

    public Transform waterSpawn;

    public float shootSpeed;

    private bool facingRight;
    private bool touchingGround;

    #endregion

    #region Hiding Detection

    public bool isHiding;


    #endregion

    private Animator playerAnimator;

    private AudioManager audioManager;

    public bool playerIsDead;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        facingRight = true;
    }

    private void Update()
    {
        FacingRightCheck();

        Shoot();

        VariablesCheck();
    }

    private void FacingRightCheck()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0) 
        {
            facingRight =false;  
        }
    }

    private void Shoot()
    {
        if (!playerIsDead)
        {
            if (!isHiding)
            {
                if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.waterShots > 0 && touchingGround)
                {
                    playerAnimator.SetTrigger("DropWater");

                    audioManager.PlaySfx(audioManager.splashZone);
                }
            }
        }
    }

    private void VariablesCheck()
    {
        isHiding = gameObject.GetComponent<StealthDroplet_SCRPT>().isHiding;
        touchingGround = gameObject.GetComponent<CharacterMovement_SCRPT>().touching;
        playerIsDead = gameObject.GetComponent<PlayerDeath_SCRPT>().playerKilled;
    }

    public void ShootPuddle()
    {
        GameObject clone = Instantiate(puddle, waterSpawn.position, waterSpawn.rotation);

        if (facingRight)
        {
            clone.GetComponentInChildren<Rigidbody2D>().AddForce(shootSpeed * transform.right);
        }
        else
        {
            clone.GetComponentInChildren<Rigidbody2D>().AddForce(-shootSpeed * transform.right);
        }

        GameManager.Instance.waterShots--;
    }

    public void FreezeInput()
    {
        gameObject.GetComponent<CharacterMovement_SCRPT>().moving = false;
    }

    public void RegainInput()
    {
        gameObject.GetComponent<CharacterMovement_SCRPT>().moving = true;
    }
}
