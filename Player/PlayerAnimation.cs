using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Collider2D playerTriggerCollider;
    [SerializeField] string pushGameObjectTag;

    private bool isPush;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Run (float direction)
    {
        if (direction > 0.01f)
        {
            animator.SetBool("movement", true);
            spriteRenderer.flipX = true;
            
        }
        else if (direction < -0.01f)
        {
            animator.SetBool("movement", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("movement", false);
        }
    }

    public void Jump (bool isGround)
    {
        if (isGround == false)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    public void Push(float direction)
    {
        if (Mathf.Abs(direction) > 0.01f && isPush)
        {
            animator.SetBool("push", true);
        }
        else
        {
            animator.SetBool("push", false);
        }
        
    }

    public void Throw()
    {
        animator.SetTrigger("throw");
    }


    public void MegaAttack(bool activate)
    {
        if (activate)
        {
            animator.SetTrigger("megaPrep");
            animator.SetBool("megaGo", activate);
        }
        else
        {
            animator.SetBool("megaGo", activate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(pushGameObjectTag))
        {
            isPush = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(pushGameObjectTag))
        {
            isPush = false;
        }
    }



    private void Update()
    {
        Run(playerMovement.GetDirectionX());
        Push(playerMovement.GetDirectionX());
        Jump(playerMovement.GetGroundedState());
    }

}
