using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool activated;
    public bool fullCart;
    Vector3 initialPosition;
    float speed = 5000;
    public GameObject full;
    SpriteRenderer renderer;
    private AudioSource ac;
    public AudioClip impactSFX;
    private void Start()
    {
        SetSpeed();
        SetState(GetState());
        initialPosition = transform.localPosition;
        ac = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (activated)
        {
            transform.localPosition += Vector3.right * Time.deltaTime * speed;
            if (transform.localPosition.x >= 4.2f)
            {
                if (fullCart)
                {
                    Score.Instance.UpdateScore(5f, new Vector3(0, 0, 0), false);
                } else {
                    Score.Instance.UpdateScore(-10f, new Vector3(0, 0, 0), false);
                }
                ReturnToStart();
            }
        }
    }
    public void ImpactSound()
    {
        ac.PlayOneShot(impactSFX);
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
            full.SetActive(true);
            renderer.color = Color.red;
        } else {
            fullCart = false;
            full.SetActive(false);
            renderer.color = Color.green;
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
}
