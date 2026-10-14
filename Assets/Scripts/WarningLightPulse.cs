using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WarningLightPulse : MonoBehaviour
{
    [SerializeField]
    private float minimumIntensity = 0.3f;
    [SerializeField]
    private float maximumIntensity = 1f;
    [SerializeField]
    private float pulseSpeed = 4f;

    private Light2D warningLight;

    void Start()
    {
        warningLight = GetComponent<Light2D>();
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

        warningLight.intensity = Mathf.Lerp(
            minimumIntensity,
            maximumIntensity,
            t
        );
    }
}
