using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelCompleteUI.SetActive(true);
        }
    }
}
