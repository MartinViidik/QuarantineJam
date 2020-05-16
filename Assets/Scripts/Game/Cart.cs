using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool activated { get; private set; }
    public bool fullCart { get; private set; }

    private Vector3 initialPosition;
    private float speed = 4;
    [SerializeField]
    private GameObject full;
    private SpriteRenderer renderer;
    private AudioSource ac;

    [SerializeField]
    private AudioClip impactSFX;
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
        speed = Random.Range(4, 6);
    }
    public void SetState(bool state)
    {
        fullCart = state;
        full.SetActive(state);
        if(state)
        {
            renderer.color = Color.red;
        } else {
            renderer.color = Color.green;
        }
    }
    bool GetState()
    {
        float RNG = Random.Range(0, 10);
        if (RNG % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ActivateCarts(bool state)
    {
        activated = state;
    }
}
