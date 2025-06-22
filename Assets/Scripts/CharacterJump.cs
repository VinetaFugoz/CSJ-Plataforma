using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField] protected float jumpImpulse = 5f;
    [SerializeField] protected bool hasDoubleJump = false;

    protected Rigidbody2D characterRigidbody;
    protected int jumpCount = 0;
    protected int maxJumps = 1;

    protected const int GROUND_LAYER = 8;

    protected virtual void Awake() =>
        characterRigidbody = GetComponent<Rigidbody2D>();

    protected virtual void Start() =>
        maxJumps = hasDoubleJump ? 2 : 1;

    public virtual void TryJump()
    {
        if (!CanJump()) return;

        characterRigidbody.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        jumpCount++;
    }

    protected bool CanJump() => jumpCount < maxJumps;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGroundCollision(collision))
            jumpCount = 0;
    }

    protected bool IsGroundCollision(Collision2D collision)
    {
        if (collision.gameObject.layer != GROUND_LAYER)
            return false;

        foreach (var contact in collision.contacts)
            if (contact.normal.y > 0.5f)
                return true;

        return false;
    }
}
