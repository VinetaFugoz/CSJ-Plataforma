using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator characterAnimator;
    private const string STATE_PARAM = "characterState";

    private void Awake() => characterAnimator = GetComponent<Animator>();

    public void UpdateState(Rigidbody2D rig, int jumpCount, float horizontal)
    {
        CharacterState state = GetCharacterState(rig, jumpCount, horizontal);
        characterAnimator.SetInteger(STATE_PARAM, (int)state);
    }

    private CharacterState GetCharacterState(Rigidbody2D rig, int jumpCount, float horizontal)
    {
        if (rig.velocity.y < -0.1f) return CharacterState.Falling;

        switch (jumpCount)
        {
            case 2: return CharacterState.DoubleJumping;
            case 1: return CharacterState.Jumping;
            default: return Mathf.Abs(horizontal) > 0.01f ? CharacterState.Walking : CharacterState.Idle;
        }
    }
}