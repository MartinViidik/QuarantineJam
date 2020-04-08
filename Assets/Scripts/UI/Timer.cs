using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int timerLength;

    [SerializeField]
    private TMP_Text timer_text;

    private float currCountdownValue;
    private bool counting;
    private void Update()
    {
        if (!counting)
        {
            timer_text.text = "";
        }
        else
        {
            timer_text.text = currCountdownValue.ToString();
        }
    }
    public IEnumerator StartCountdown(int countdownValue)
    {
        counting = true;
        currCountdownValue = countdownValue;
        GameController.Instance.IncreaseTempo(0.025f);
        timer_text.DOFade(1, 0.5f);
        while (currCountdownValue >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            timer_text.transform.DOShakeScale(0.1F, 0.5F, 2, 0, true);
            if(currCountdownValue == 3)
            {
                timer_text.DOColor(Color.red, 0.5f);
            }
            if(currCountdownValue == 0)
            {
                timer_text.DOFade(0.0f, 0.75f);
            }
        }
        StartCoroutine(StopCountdown());
        timer_text.DOColor(Color.white, 0.1f);
        counting = false;
    }
    public IEnumerator StopCountdown()
    {
        yield return new WaitForSeconds(1.0f);
        Scenemanager.Instance.StartTransition();
    }
    public IEnumerator NewScene()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(StartCountdown(timerLength));
    }
    public void SceneChanged()
    {
        if (!Scenemanager.Instance.IsGameOver())
        {
            StartCoroutine(NewScene());
        }
    }
    public void StopTimer()
    {
        StopAllCoroutines();
        counting = false;
    }
}
