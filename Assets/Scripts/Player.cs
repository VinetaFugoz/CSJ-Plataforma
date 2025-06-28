using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D characterRig;
    private CharacterMovement characterMovement;
    private CharacterJump characterJump;
    private CharacterVisual characterVisual;
    private CharacterAnimation characterAnimation;

    private void Awake()
    {
        characterRig = GetComponent<Rigidbody2D>();
        characterVisual = GetComponent<CharacterVisual>();
        characterMovement = GetComponent<CharacterMovement>();
        characterJump = GetComponent<CharacterJump>();
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        bool hasJumpInput = Input.GetButtonDown("Jump");

        characterVisual.FaceDirection(horizontalInput);

        characterMovement.Move(characterRig, horizontalInput);

        if (hasJumpInput) characterJump.Jump(characterRig);

        characterAnimation.UpdateState(characterRig, characterJump.jumpCount, horizontalInput);
    }
}
