using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    public TMP_Text score_text;
    public float score = 0;

    private static Score _instance;
    public GameObject scoreIndicator;
    public TMP_Text scoreIndicatortext;

    public GameObject finalScoreText;
    public TMP_Text finalScore;

    public AudioClip scoreSFX;
    public AudioClip negativeSFX;
    public AudioClip countSFX;
    private AudioSource ac;

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
        ac = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateScore(float amount, Vector3 inputPosition, bool mouse)
    {
        if(amount >= 0)
        {
            ac.PlayOneShot(scoreSFX);
        } else {
            ac.PlayOneShot(negativeSFX);
        }
        SetIndicatorText(amount);
        score += amount;
        score_text.text = score.ToString();
        ShowIndicator(inputPosition, mouse);
    }

    public void ShowIndicator(Vector3 InputPosition, bool mouse)
    {
        if (!scoreIndicator.activeInHierarchy)
        {
            scoreIndicator.SetActive(true);
            if (mouse)
            {
                scoreIndicator.transform.position = InputPosition;
            } else {
                scoreIndicator.transform.localPosition = InputPosition;
            }
        }
    }

    private IEnumerator FinalScoreCounter()
    {
        int i = 0;
        yield return new WaitForSeconds(1.5f);
        finalScoreText.SetActive(true);
        while (i != score)
        {
            if (!ac.isPlaying)
            {
                ac.PlayOneShot(countSFX);
            }
            if(i > score)
            {
                yield return new WaitForSeconds(0.0045f);
                i--;
                finalScore.text = i.ToString();
            } else {
                yield return new WaitForSeconds(0.0045f);
                i++;
                finalScore.text = i.ToString();
            }
        }
        ac.Stop();
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

    void SetIndicatorText(float amount)
    {
        if(amount >= 0)
        {
            scoreIndicatortext.text = "+" + amount.ToString();
            scoreIndicatortext.color = Color.white;
        } else {
            scoreIndicatortext.text = "-" + amount.ToString();
            scoreIndicatortext.color = Color.red;
        }
    }
}
