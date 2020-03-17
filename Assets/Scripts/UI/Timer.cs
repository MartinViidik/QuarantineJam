using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timer_text;
    float currCountdownValue;
    bool counting;
    private void Update()
    {
        if (!counting)
        {
            timer_text.text = "";
        } else {
            timer_text.text = currCountdownValue.ToString();
        }
    }
    public IEnumerator StartCountdown(int countdownValue)
    {
        counting = true;
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        StartCoroutine(StopCountdown());
        counting = false;
    }

    public IEnumerator StopCountdown()
    {
        yield return new WaitForSeconds(1.0f);
        Scenemanager.Instance.loadScene();
    }

    public IEnumerator NewScene()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(StartCountdown(1));
    }

    public void SceneChanged()
    {
        StartCoroutine(NewScene());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        counting = false;
    }
}
