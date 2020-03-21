using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool activated;
    public bool fullCart;
    Vector3 initialPosition;
    float speed;
    public SpriteRenderer renderer;
    private void Start()
    {
        SetSpeed();
        SetState();
        initialPosition = transform.localPosition;
    }
    private void Awake()
    {
        renderer = renderer.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (activated)
        {
            transform.localPosition += Vector3.right * Time.deltaTime * speed;
            if (transform.localPosition.x > 4)
            {
                ReturnToStart();
            }
        }
    }
    void ReturnToStart()
    {
        SetSpeed();
        SetState();
        transform.localPosition = initialPosition;
    }

    void SetSpeed()
    {
        speed = Random.Range(3, 4);
    }
    void SetState()
    {
        float RNG = Random.Range(0, 10);
        Debug.Log(RNG);
        if(RNG % 2 == 0)
        {
            fullCart = true;
            SetColor(Color.red);
        } else {
            fullCart = false;
            SetColor(Color.white);
        }
    }
    void SetColor(Color color)
    {
        renderer.material.color = color;
    }
}
