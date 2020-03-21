using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool activated;
    Vector3 initialPosition;
    float speed;
    private void Start()
    {
        SetSpeed();
        initialPosition = transform.localPosition;
    }
    void Update()
    {
        if (activated)
        {
            transform.localPosition += Vector3.right * 0.15f;
            if (transform.localPosition.x > 4)
            {
                ReturnToStart();
            }
            Debug.Log(speed);
        }
    }
    void ReturnToStart()
    {
        SetSpeed();
        transform.localPosition = initialPosition;
    }

    void SetSpeed()
    {
        speed = Random.Range(0.001f, 0.0075f);
    }
}
