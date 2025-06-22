using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    protected Rigidbody2D characterRigidbody;

    protected virtual void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Move(float direction)
    {
        characterRigidbody.velocity = new Vector2(direction * moveSpeed, characterRigidbody.velocity.y);
    }
}