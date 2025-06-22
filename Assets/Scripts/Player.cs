using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterMovement movement;
    private CharacterJump jump;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        jump = GetComponent<CharacterJump>();
    }

    private void Update()
    {
        movement.Move(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump")) jump.TryJump();
    }
}
