using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpOffset;
    [SerializeField] private bool isGrounded = false;
    [Header("Settings")]
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private GameObject colliderPlayer;
    [SerializeField] private PhysicsMaterial2D materialPlayer;

    private Rigidbody2D rigidBody2D;
    private float DirectionX;
    private float DirectionY;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    public void Move(float directionX, bool isJumpButtonPressed)
    {
        DirectionX = directionX;
        if (isJumpButtonPressed) Jump();
        if (Mathf.Abs(directionX) > 0.01f) 
        {
            HorizontalMovement(directionX);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpForce);
        }
    }

    public void HorizontalMovement(float direction)
    {
        rigidBody2D.velocity = new Vector2(direction * Speed, rigidBody2D.velocity.y);
    }

    private void CheckGround()
    {
        //new Vector2(0.50f, 1) Size cube Cast 0 angle
        var hit = Physics2D.BoxCast(colliderPlayer.transform.position, new Vector2(0.50f, 1), 0, Vector2.down, JumpOffset, GroundMask);
        if (hit)
        {
            isGrounded = true;
            RefreshCollider(1f);
        }
        else if (hit == false)
        {
            isGrounded = false;
            RefreshCollider(0f);
        }
    }
    
    private void RefreshCollider(float friction)
    {

        materialPlayer.friction = friction;
        colliderPlayer.SetActive(false);
        colliderPlayer.SetActive(true);
    }

    public bool GetGroundedState()
    {
        return isGrounded;
    }

    public float GetDirectionX()
    {
        return DirectionX;
    }

    public float GetDirectionY()
    {
        return DirectionY;
    }

    #region TouchPad

    #endregion
}
