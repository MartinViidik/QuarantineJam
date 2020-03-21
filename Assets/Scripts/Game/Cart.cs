using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool activated;
    public bool fullCart;
    Vector3 initialPosition;
    float speed = 100;
    public SpriteRenderer renderer;
    private void Start()
    {
        SetSpeed();
        SetState(GetState());
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
        SetState(GetState());
        transform.localPosition = initialPosition;
    }

    void SetSpeed()
    {
        speed = Random.Range(3, 4);
    }
    public void SetState(bool state)
    {
        if(state == true)
        {
            fullCart = true;
            SetColor(Color.red);
        } else {
            fullCart = false;
            SetColor(Color.white);
        }
    }
    bool GetState()
    {
        float RNG = Random.Range(0, 10);
        Debug.Log(RNG);
        if (RNG % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void SetColor(Color color)
    {
        renderer.material.color = color;
    }
}
