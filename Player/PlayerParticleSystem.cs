using UnityEngine;

public class PlayerParticleSystem : MonoBehaviour
{
    [SerializeField] private GameObject Run;
    [SerializeField] private GameObject Jump;

    private PlayerMovement playerMovement;
    private bool enableGround = true;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void IsMovement(float direction, bool isGrounded)
    {
        if (Mathf.Abs(direction) > 0.01f && isGrounded)
        {
            Run.SetActive(true);
        }
        else
        {
            Run.SetActive(false);
        }
    }
    public void IsGrounded(bool isGround)
    {
        if (isGround && enableGround)
        {
            Jump.SetActive(true);
            enableGround = false;
        }
        else if(!isGround)
        {
            enableGround = true;
        }
    }

    private void Update()
    {
        IsMovement(playerMovement.GetDirectionX(), playerMovement.GetGroundedState());
        IsGrounded(playerMovement.GetGroundedState());
    }
}
