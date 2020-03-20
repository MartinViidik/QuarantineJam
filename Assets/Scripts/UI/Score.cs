using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    public TMP_Text score_text;
    public float score = 0;
    private static Score _instance;
    public GameObject scoreIndicator;

    public GameObject finalScoreText;
    public TMP_Text finalScore;

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

    private IEnumerator FinalScoreCounter()
    {
        int i = 0;
        yield return new WaitForSeconds(1.5f);
        finalScoreText.SetActive(true);
        while (i != score)
        {
            if(i > score)
            {
                yield return new WaitForSeconds(0.01f);
                i--;
                finalScore.text = i.ToString();
            } else {
                yield return new WaitForSeconds(0.01f);
                i++;
                finalScore.text = i.ToString();
            }
        }
        MenuController.Instance.LoadMenu("endgame");
    }

    public void HideScore(bool finalScore)
    {
        score_text.text = "";
        if (finalScore)
        {
            StartCoroutine(FinalScoreCounter());
        }
    }

    public void ResetScore()
    {
        finalScoreText.SetActive(false);
        score = 0;
    }
}
