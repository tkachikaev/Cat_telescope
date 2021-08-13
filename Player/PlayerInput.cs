using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    public Joystick joystick;
    private PlayerMovement playerMovement;
    private bool jumpPressed;
    

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        playerMovement.Move(joystick.Horizontal, jumpPressed);
        jumpPressed = false;
    }

    public void IsJumpButtonPressd()
    {
        jumpPressed = true;
    }
    public void IsJumpButtonNotPressd()
    {
        jumpPressed = false;
    }
}
