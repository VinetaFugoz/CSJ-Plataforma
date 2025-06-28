using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    public void FaceDirection(float direction)
    {
        if (direction == 0) return;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(direction) * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}