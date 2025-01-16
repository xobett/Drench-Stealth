using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement_SCRPT : MonoBehaviour
{
    [Header("Enemy Movement")]

    public Rigidbody2D enemyRb;

    public float speedEnemy;
    public float speedEnemyRunning;

    public Transform a;
    public Transform b;

    private Vector2 newpos;
    private Vector2 target;

    public bool enemyMoving;

    [Header("Player Detection")]

    private GameObject player;

    public bool playerFound;

    [Header("Unfreeze Enemy Timer")]

    public float unfreezeTimer;
    public float unfreezeWaitTime;

    public bool enemyUnfreezed;

    #region Animator and Flip 

    private AudioManager audioManager;

    private bool facingLeft;

    private Animator enemyAnimator;

    #endregion


    private void Start()
    {
        Application.targetFrameRate = 60;

        enemyAnimator = GetComponent<Animator>();

        enemyRb = GetComponent<Rigidbody2D>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        target = a.position;

        enemyMoving = true;
        facingLeft = true;
    }

    private void Update()
    {
        DirectionCheck();

        UnfreezeTimer();
    }

    private void DirectionCheck()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (enemyMoving)
        {
            if (playerFound)
            {
                target = player.transform.position;
                FacingPlayerTest();

                newpos = Vector2.MoveTowards(enemyRb.position, target, speedEnemyRunning * Time.deltaTime);
                enemyRb.MovePosition(newpos);
            }
            else
            {
                if (Vector2.Distance(enemyRb.position, a.position) < 0.2f && facingLeft)
                {
                    target = b.position;
                    Flip();
                }
                else if ((Vector2.Distance(enemyRb.position, b.position) < 0.2) && !facingLeft)
                {
                    target = a.position;
                    Flip();
                }

                newpos = Vector2.MoveTowards(enemyRb.position, target, speedEnemy * Time.deltaTime);
                enemyRb.MovePosition(newpos);
            }

            //newpos = Vector2.MoveTowards(enemyRb.position, target, speedEnemy * Time.deltaTime);
            //enemyRb.MovePosition(newpos);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerFound = true;

            enemyAnimator.SetBool("playerIsDetected", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerFound = false;

            enemyAnimator.SetBool("playerIsDetected", false);

            if (facingLeft)
            {
                target = b.position;
                Flip();
            }
            else if (!facingLeft)
            {
                target = a.position;
                Flip();
            }
        }
    }

    private void FacingPlayerTest()
    {
        if (player.transform.position.x < transform.position.x && !facingLeft)
        {
            Flip();
        }
        else if (player.transform.position.x > transform.position.x && facingLeft)
        {
            Flip();
        }
    }

    public void FreezedMovement()
    {
        enemyMoving = false;
        unfreezeTimer = unfreezeWaitTime;
        enemyUnfreezed = true;

        gameObject.layer = 4;

        enemyAnimator.SetBool("isFrozen", true);

        audioManager.PlaySfx(audioManager.enemyFreezing);
    }

    private void RegainedMovement()
    {
        enemyMoving = true;

        gameObject.layer = 9;
    }

    private void UnfreezeTimer()
    {
        unfreezeTimer -= Time.deltaTime;

        if (unfreezeTimer < 0)
        {
            if (enemyUnfreezed)
            {
                RegainedMovement();
                enemyUnfreezed = false;

                enemyAnimator.SetBool("isFrozen", false);
            }
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
