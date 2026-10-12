
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class MovingHazard : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float pauseDuration = 1.5f;
    [SerializeField]
    private float warningDuration = 0.5f;

    [SerializeField]
    private Light2D warningLight;

    private Transform target;
    private bool isPaused = false;
    private float pauseTimer = 0f;

    void Start()
    {
        target = pointB;
        UpdateWarningLight();
    }

    void Update()
    {
        if (isPaused)
        {
            pauseTimer += Time.deltaTime;

            // Warn the player just before moving again.
            if (pauseTimer >= pauseDuration - warningDuration)
            {
                warningLight.color = Color.red;
            }
            else
            {
                warningLight.color = Color.yellow;
            }

            if (pauseTimer >= pauseDuration)
            {
                isPaused = false;
                pauseTimer = 0f;
                target = target == pointA ? pointB : pointA;

                UpdateWarningLight();
            }

            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.01f)
        {
            isPaused = true;
            pauseTimer = 0f;
            UpdateWarningLight();
        }
    }

    void UpdateWarningLight()
    {
        if (warningLight == null)
            return;

        warningLight.color = isPaused ? Color.yellow : Color.green;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
