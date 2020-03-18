using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool selected;
    public Vector3 inputPOS;

    public void GetRubbed()
    {
        if (!selected)
        {
            StartCoroutine(RubCoroutine());
        }
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

    private void Update()
    {
        Debug.Log(inputPOS);
    }
}
