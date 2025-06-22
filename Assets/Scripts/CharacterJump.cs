using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField] protected float jumpImpulse = 5f;
    [SerializeField] protected bool hasDoubleJump = false;
    [SerializeField] private LayerMask groundLayer;
    protected int jumpCount = 0;
    protected int maxJumps = 1;

    protected virtual void Start() => maxJumps = hasDoubleJump ? 2 : 1;

    public virtual void HandleJump(Rigidbody2D characterRig)
    {
        if (!CanJump()) return;
        Jump(characterRig);
        jumpCount++;
    }

    private void Jump(Rigidbody2D characterRig) => characterRig.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);

    protected bool CanJump() => jumpCount < maxJumps;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGroundCollision(collision))
            jumpCount = 0;
    }

    protected bool IsGroundCollision(Collision2D collision)
    {
        if (collision.gameObject.layer != groundLayer)
            return false;

        foreach (var contact in collision.contacts)
            if (contact.normal.y > 0.5f)
                return true;

        return false;
    }
}
