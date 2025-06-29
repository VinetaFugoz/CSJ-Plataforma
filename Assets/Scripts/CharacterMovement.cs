using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    public virtual void Move(Rigidbody2D characterRig, float direction)
    {
        if (characterRig == null) return;
        
        characterRig.velocity = new Vector2(direction * moveSpeed, characterRig.velocity.y);
    }
    
    public bool IsMoving(float direction) => Mathf.Abs(direction) > 0.01f;
}