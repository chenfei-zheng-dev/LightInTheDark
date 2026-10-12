using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    private Collider2D trapCollider;
    private SpriteRenderer trapRenderer;

    void Start()
    {
        trapCollider = GetComponent<Collider2D>();
        trapRenderer = GetComponent<SpriteRenderer>();

        SetTrapActive(false);
    }

    public void SetTrapActive(bool active)
    {
        trapCollider.enabled = active;
        trapRenderer.enabled = active;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
