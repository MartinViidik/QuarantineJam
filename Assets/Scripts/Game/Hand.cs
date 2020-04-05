using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private bool selected;
    private bool handEnabled;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject foam;

    private AudioSource ac;
    public Vector3 inputPOS;

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
        ac = GetComponent<AudioSource>();
    }
    private IEnumerator RubCoroutine()
    {
        selected = true;
        SetWashingAnimation(true);
        ac.volume = 0.5f;
        foam.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Score.Instance.UpdateScore(1, inputPOS, true);
        selected = false;
    }
    public void StopRubbing()
    {
        ac.volume = 0;
        selected = false;
        StopAllCoroutines();
        SetWashingAnimation(false);
        foam.SetActive(false);
    }
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("washhands");
        yield return new WaitForSeconds(3f);
        handEnabled = true;
    }
    void SetWashingAnimation(bool state)
    {
        anim.SetBool("Washing", state);
    }
}
