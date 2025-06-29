using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpImpulse = 5f;
    [SerializeField] private bool hasDoubleJump = false;
    [SerializeField] private LayerMask groundLayer = -1;
    
    public int jumpCount = 0;
    private int maxJumps;

    private void Awake()
    {
        maxJumps = hasDoubleJump ? 2 : 1;
    }

    public virtual void Jump(Rigidbody2D characterRig)
    {
        if (!CanJump()) return;
        
        characterRig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        jumpCount++;
    }

    private bool CanJump() => jumpCount < maxJumps;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasGroundCollision(collision)) 
        {
            jumpCount = 0;
        }
    }

    private bool HasGroundCollision(Collision2D collision)
    {
        if (!IsOnGroundLayer(collision)) return false;
        
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.contacts[i].normal.y > 0.5f)
                return true;
        }
        return false;
    }

    private bool IsOnGroundLayer(Collision2D collision)
    {
        return (groundLayer.value & (1 << collision.gameObject.layer)) != 0;
    }
} 