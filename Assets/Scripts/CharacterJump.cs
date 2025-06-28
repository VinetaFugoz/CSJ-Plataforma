using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] protected float jumpImpulse = 5f;
    private int maxJumps = 1;
    [SerializeField] protected bool _hasDoubleJump = false;
    public bool HasDoubleJump
    {
        get => _hasDoubleJump;
        set
        {
            _hasDoubleJump = value;
            maxJumps = value ? 2 : 1;
        }
    }
    [SerializeField] private LayerMask groundLayer;
    public int jumpCount = 0;
    

    public virtual void Jump(Rigidbody2D characterRig)
    {
        if (!CanJump()) return;
        ApplyJumpForce(characterRig);
        IncrementJumpCount();
    }

    protected bool CanJump() => jumpCount < maxJumps;

    private void ApplyJumpForce(Rigidbody2D characterRig)
    {
        characterRig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
    }

    private void IncrementJumpCount() => jumpCount++;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasGroundCollision(collision)) ResetJumpCount();
    }

    private void ResetJumpCount() => jumpCount = 0;

    private bool HasGroundCollision(Collision2D collision) => IsOnGroundLayer(collision) && HasContactBelow(collision);

    private bool IsOnGroundLayer(Collision2D collision) => (groundLayer.value & (1 << collision.gameObject.layer)) != 0;

    private bool HasContactBelow(Collision2D collision) => collision.contacts.Any(contact => contact.normal.y > 0.5f);
}
