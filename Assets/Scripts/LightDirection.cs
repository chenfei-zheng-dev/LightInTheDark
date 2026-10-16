using UnityEngine;

public class LightDirection : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    void Update()
    {
        if (playerMovement == null)
            return;

        Vector2 direction = playerMovement.LastMoveDirection;

        if (direction == Vector2.zero)
            return;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Spot Light 2D points along its local up direction.
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
