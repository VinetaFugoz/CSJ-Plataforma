using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D characterRig;
    private CharacterMovement movement;
    private CharacterJump jump;

    private void Awake()
    {
        characterRig = GetComponent<Rigidbody2D>();
        movement = GetComponent<CharacterMovement>();
        jump = GetComponent<CharacterJump>();
    }

    private void Update()
    {
        movement.Move(Input.GetAxis("Horizontal"), characterRig);
        if (Input.GetButtonDown("Jump")) jump.HandleJump(characterRig);
    }
}
