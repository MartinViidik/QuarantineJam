using UnityEngine;

public class Background : MonoBehaviour
{
    private static Background _instance;
    public static Background Instance
    {
        get { return _instance; }
    }

    private float timeLeft;
    private bool active = false;
    private Color targetColor;
    private Renderer renderer;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (active)
        {
            if (timeLeft <= Time.deltaTime)
            {
                renderer.material.color = targetColor;

                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
                active = false;
            }
            else
            {
                renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);

                timeLeft -= Time.deltaTime;
            }
        }
    }

    public void StartTransition()
    {
        active = true;
    }
}
