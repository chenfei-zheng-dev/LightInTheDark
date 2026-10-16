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

    [SerializeField]
    [Range(1f, 180f)]
    private float beamAngle = 60f;

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
                Vector2 beamDirection = playerLight.transform.up;

                float angleToCrystal = Vector2.Angle(beamDirection, direction);

                if (angleToCrystal <= beamAngle / 2f)
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
