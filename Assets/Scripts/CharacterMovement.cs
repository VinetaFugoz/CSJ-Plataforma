using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    public virtual void Move(float direction, Rigidbody2D characterRig)
    {
        characterRig.velocity = new Vector2(direction * moveSpeed, characterRig.velocity.y);
    }
}