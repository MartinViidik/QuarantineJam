using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text score_text;

    private float _score;
    public float score
    {
        get { return _score; }
    }

    private static Score _instance;
    [SerializeField]
    private GameObject scoreIndicator;

    [SerializeField]
    private TMP_Text scoreIndicatortext;

    [SerializeField]
    private GameObject finalScoreText;
    [SerializeField]
    private TMP_Text finalScore;

    [SerializeField]
    private AudioClip scoreSFX;
    [SerializeField]
    private AudioClip negativeSFX;
    [SerializeField]
    private AudioClip countSFX;
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
    }
    public void UpdateScore(float amount, Vector3 inputPosition, bool mouse)
    {
        if(amount >= 0)
        {
            ac.PlayOneShot(scoreSFX);
        } else {
            ac.PlayOneShot(negativeSFX);
        }
        if(amount > 0)
        {
            StartCoroutine("TurnColor", Color.green);
            score_text.transform.DOShakeScale(0.1F, 0.5F, 2, 0, true);
        } else {
            StartCoroutine("TurnColor",Color.red);
            score_text.transform.DOShakeScale(0.1F, -0.5F, 2, 0, true);
        }
        SetIndicatorText(amount);
        _score += amount;
        score_text.text = _score.ToString();
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
            scoreIndicatortext.transform.DOPunchScale(new Vector3(1.15f,1.15f), 0.25f, 2, 0);
        }
    }
    private IEnumerator FinalScoreCounter()
    {
        float i = 0;
        yield return new WaitForSeconds(1.5f);
        finalScoreText.SetActive(true);
        while (i != score)
        {
            if (Input.GetMouseButtonDown(0))
            {
                i = score;
            }
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
        Scenemanager.Instance.LoadRetry();
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
        _score = 0;
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

    private IEnumerator TurnColor(Color color)
    {
        score_text.DOColor(color, 0.1f);
        yield return new WaitForSeconds(0.1f);
        score_text.DOColor(Color.white, 0.1f);
    }
}
