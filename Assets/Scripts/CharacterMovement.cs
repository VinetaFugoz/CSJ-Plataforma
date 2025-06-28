using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] protected float moveSpeed = 5f;

    public virtual void Move(Rigidbody2D characterRig, float direction)
    {
        characterRig.velocity = new Vector2(direction * moveSpeed, characterRig.velocity.y);
    }
}