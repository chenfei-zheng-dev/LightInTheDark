using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BatteryGlowAnimation : MonoBehaviour
{
    public float minimumIntensity = 0.3f;
    public float maximumIntensity = 0.6f;
    public float speed = 2f;

    private Light2D light2D;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;

        light2D.intensity = Mathf.Lerp(minimumIntensity, maximumIntensity, t);
    }
}