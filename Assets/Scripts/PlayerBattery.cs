using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerBattery : MonoBehaviour
{
    [SerializeField]
    private float maxBattery = 100f;
    [SerializeField]
    private float currentBattery;

    [SerializeField]
    private Light2D playerLight;

    [SerializeField]
    private float drainRate = 5f;

    private float originalIntensity;

    private void Start()
    {
        currentBattery = maxBattery;
        originalIntensity = playerLight.intensity;
    }

    void Update()
    {
        currentBattery -= drainRate * Time.deltaTime;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);

        float energyPercentage = currentBattery / maxBattery;
        playerLight.intensity = originalIntensity * energyPercentage;
        
    }

    public float CurrentBattery
    {
        get { return currentBattery; }
    }

    public void AddEnergy(float amount)
    {
        currentBattery += amount;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
    }
}