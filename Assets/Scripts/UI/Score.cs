using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    public TMP_Text score_text;
    public float score = 0;
    private static Score _instance;
    public GameObject scoreIndicator;
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
        Debug.Log(score);
    }

    public void ShowIndicator(Vector3 InputPosition)
    {
        scoreIndicator.SetActive(true);
        scoreIndicator.transform.position = InputPosition;
        StartCoroutine(DisableIndicator());
    }

    private IEnumerator DisableIndicator()
    {
        yield return new WaitForSeconds(0.25f);
        scoreIndicator.SetActive(false);
    }
}
