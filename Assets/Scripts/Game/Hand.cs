using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool selected;
    public Vector3 inputPOS;
    bool handEnabled;

    public void GetRubbed()
    {
        if (!selected)
        {
            StartCoroutine(RubCoroutine());
        }
    }

    private void Start()
    {
        StartCoroutine(InitialDelay());
    }

    private IEnumerator RubCoroutine()
    {
        selected = true;
        yield return new WaitForSeconds(0.25f);
        Score.Instance.UpdateScore(1);
        Score.Instance.ShowIndicator(inputPOS);
        selected = false;
    }

    public void StopRubbing()
    {
        selected = false;
        StopAllCoroutines();
    }

    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("Wash your hands!");
        yield return new WaitForSeconds(3f);
        handEnabled = true;
    }
}
