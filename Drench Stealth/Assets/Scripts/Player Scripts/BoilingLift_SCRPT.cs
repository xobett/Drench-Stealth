using UnityEngine;

public class BoilingLift_SCRPT : MonoBehaviour
{
    public GameObject cloud;

    private Animator playerAnimator;
    private Animator puddleAnimatorBoiling;

    private AudioManager audioManager;

    public Transform cloudSpawn;

    public bool cloudCheck;
    public bool playerHiding;
    public bool playerIsDead;

    private void Start()
    {
        puddleAnimatorBoiling = transform.parent.gameObject.GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        Boil();
        VariablesCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cloudCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cloudCheck = false;
        }
    }

    private void Boil()
    {
        if (!playerIsDead)
        {
            if (cloudCheck)
            {
                if (!playerHiding)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        playerAnimator.SetTrigger("BoilingLift");

                        audioManager.PlaySfx(audioManager.boilingLift);

                        GameObject cloneCloud = Instantiate(cloud, cloudSpawn.position, cloudSpawn.rotation);

                        puddleAnimatorBoiling.SetTrigger("Evaporate Puddle");
                    }
                }
            }
        }
    }

    private void VariablesCheck()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerHiding = GameObject.FindGameObjectWithTag("Player").GetComponent<StealthDroplet_SCRPT>().isHiding;
        playerIsDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath_SCRPT>().playerKilled;
    }
}
