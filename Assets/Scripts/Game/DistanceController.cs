using System.Collections;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public Person[] people;
    bool timer = false;
    void Start()
    {
        StartCoroutine(InitialDelay());
    }
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("Keep a distance!");
        yield return new WaitForSeconds(3f);
        StartGame();
    }

    void StartGame()
    {
        for(int i = 0; i <= people.Length; i++)
        {
            people[i].SetMoving();
        }
    }
    public void TalkingTimer()
    {
        if (!timer)
        {
            StartCoroutine(TalkingDelay());
            timer = true;
        } else {
            return;
        }
    }

    private IEnumerator TalkingDelay()
    {
        yield return new WaitForSeconds(0.15f);
        Score.Instance.UpdateScore(-25, new Vector3(0, 0, 0), false);
        yield return new WaitForSeconds(0.5f);
        timer = false;
    }
}
