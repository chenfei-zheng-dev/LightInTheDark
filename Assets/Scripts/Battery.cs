using System.Collections;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private float energyAmount = 25f;
    [SerializeField]
    private float pickupDuration = 0.2f;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected)
            return;

        if (other.CompareTag("Player"))
        {
            PlayerBattery playerBattery = other.GetComponent<PlayerBattery>();

            if (playerBattery != null)
            {
                collected = true;
                playerBattery.AddEnergy(energyAmount);
                Destroy(gameObject);

                StartCoroutine(PickupAnimation());
            }
        }
    }

    private IEnumerator PickupAnimation()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;

        Vector3 startScale = transform.localScale;

        float elapsed = 0f;

        while (elapsed < pickupDuration)
        {
            elapsed += Time.deltaTime;

            float progress = elapsed / pickupDuration;

            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, progress);

            yield return null;
        }

        Destroy(gameObject);
    }
}