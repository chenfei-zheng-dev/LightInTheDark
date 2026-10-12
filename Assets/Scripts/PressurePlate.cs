using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private SpikeTrap trap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trap.SetTrapActive(true);
        }
    }
}
