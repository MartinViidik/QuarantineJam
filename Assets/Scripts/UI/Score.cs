using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text score_text;
    public float score = 0;
    private static Score _instance;
    public static Score Instance
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

    public void UpdateScore(float amount)
    {
        score += amount;
        score_text.text = score.ToString();
    }
}
