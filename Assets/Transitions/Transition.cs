using System.Collections;
using UnityEngine;
public class Transition : MonoBehaviour
{
    SimpleBlit blit;
    float val = 1;
    public string fadeState = "none";

    private static Transition _instance;
    public static Transition Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        blit = GetComponent<SimpleBlit>();
        blit.TransitionMaterial.SetFloat("_Fade", 1);
    }
    void Update()
    {
        if (fadeState == "out")
        {
            val -= Time.deltaTime * 3;
            val = Mathf.Clamp01(val);
            blit.TransitionMaterial.SetFloat("_Cutoff", val);
        }
        else if (fadeState == "in")
        {
            val += Time.deltaTime * 3;
            val = Mathf.Clamp01(val);
            blit.TransitionMaterial.SetFloat("_Cutoff", val);
        }
        if (val == 0 || val == 1)
        {
            fadeState = "none";
        }
    }

    public void SetState(float delay, string newState)
    {
        StartCoroutine(StateCoroutine(delay, newState));
    }

    private IEnumerator StateCoroutine(float delay, string newState)
    {
        yield return new WaitForSeconds(delay);
        fadeState = newState;
    }

    public void SetCutoff(float val)
    {
        StopAllCoroutines();
        blit.TransitionMaterial.SetFloat("_Cutoff", val);
    }
}
