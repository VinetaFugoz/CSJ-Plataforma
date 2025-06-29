using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    [Header("Animation Thresholds")]
    [SerializeField] private float fallThreshold = -0.1f;
    [SerializeField] private float movementThreshold = 0.01f;

    private const String PLAYER_STATE_PARAM = "playerState";

    private Animator characterAnimator;
    
    // Cache para performance
    private static readonly int STATE_PARAM = Animator.StringToHash(PLAYER_STATE_PARAM);

    private void Awake()
    {
        characterAnimator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Rigidbody2D rig, int jumpCount, float horizontal)
    {
        if (rig == null || characterAnimator == null) return;

        CharacterState state = GetCharacterState(rig, jumpCount, horizontal);
        characterAnimator.SetInteger(STATE_PARAM, (int) state);
    }

    private CharacterState GetCharacterState(Rigidbody2D rig, int jumpCount, float horizontal)
    {
        if (rig.velocity.y < fallThreshold) return CharacterState.Falling;

        return jumpCount switch
        {
            2 => CharacterState.DoubleJumping,
            1 => CharacterState.Jumping,
            _ => Mathf.Abs(horizontal) > movementThreshold ? CharacterState.Walking : CharacterState.Idle,
        };
    }
} 