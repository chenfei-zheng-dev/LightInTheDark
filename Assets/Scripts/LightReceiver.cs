using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightReceiver : MonoBehaviour
{
    [SerializeField]
    private Light2D playerLight;
    [SerializeField]
    private DoorController door;

    [SerializeField]
    private LayerMask blockingLayers;
    private SpriteRenderer spriteRenderer;
    private bool isLit;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerLight == null)
            return;

        bool currentlyLit = IsLightReachingCrystal();

        if (currentlyLit != isLit)
        {
            isLit = currentlyLit;
            UpdateCrystal();
        }
    }

    bool IsLightReachingCrystal()
    {
        bool isLit = false;

        if (playerLight.enabled && playerLight.intensity > 0.05f)
        {
            Vector2 lightPosition = playerLight.transform.position;
            Vector2 crystalPosition = transform.position;

            Vector2 direction = crystalPosition - lightPosition;
            float distance = direction.magnitude;

            if (distance <= playerLight.pointLightOuterRadius)
            {
                RaycastHit2D hit = Physics2D.Raycast(
                    lightPosition,
                    direction.normalized,
                    distance,
                    blockingLayers
                );

                isLit = hit.collider == null;
            }
        }

        return isLit;
    }
    void UpdateCrystal()
    {
        spriteRenderer.color = isLit
            ? Color.cyan
            : Color.gray;

        if (door != null)
        {
            door.SetOpen(isLit);
        }
    }
}
