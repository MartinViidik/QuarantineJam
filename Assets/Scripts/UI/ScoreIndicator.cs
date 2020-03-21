using System.Collections;
using UnityEngine;

public class ScoreIndicator : MonoBehaviour
{
    int speed = 4;
    void Update()
    {
        if (isActiveAndEnabled)
        {
            transform.localPosition += Vector3.up * speed;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DisableIndicator());
    }

    private IEnumerator DisableIndicator()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
}
