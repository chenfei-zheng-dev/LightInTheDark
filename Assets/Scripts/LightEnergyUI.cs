using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightEnergyUI : MonoBehaviour
{
    [SerializeField]
    private PlayerBattery playerBattery;

    [SerializeField]
    private Slider energyBar;

    [SerializeField]
    private TMP_Text percentageText;

    void Update()
    {
        energyBar.value = playerBattery.CurrentBattery;

        percentageText.text = Mathf.RoundToInt(playerBattery.CurrentBattery) + "%";
    }
}
