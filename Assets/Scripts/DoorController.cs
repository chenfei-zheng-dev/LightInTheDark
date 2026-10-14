using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void SetOpen(bool open)
    {
        Collider2D doorCollider = GetComponent<Collider2D>();
        SpriteRenderer doorRenderer = GetComponent<SpriteRenderer>();

        if (doorCollider != null)
            doorCollider.enabled = !open;

        if (doorRenderer != null)
            doorRenderer.enabled = !open;
    }
}
