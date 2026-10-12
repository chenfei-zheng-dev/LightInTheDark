using UnityEngine;

public class BatteryAnimation : MonoBehaviour
{
    public float height = 0.1f;
    public float speed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height;

        transform.localPosition = startPosition + new Vector3(0f, newY, 0f);
    }
}