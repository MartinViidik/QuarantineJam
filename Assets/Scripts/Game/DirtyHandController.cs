using System.Collections;
using UnityEngine;

public class DirtyHandController : MonoBehaviour
{
    [SerializeField]
    private AudioClip pokeSFX;

    private AudioSource ac;

    [SerializeField]
    private GameObject dirtyHand;

    [SerializeField]
    private GameObject _target;
    public GameObject target
    {
        get { return _target; }
    }
    private void Awake()
    {
        for(int i = 0; i <= 10; i++)
        {
            GameObject _dirtyHand = Instantiate(dirtyHand, transform);
            _dirtyHand.SetActive(false);
        }

        ac = GetComponent<AudioSource>();
        StartCoroutine(InitialDelay());
    }
    public IEnumerator SpawnHand()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            GetHand();
        }
    }
    public void GetHand()
    {
        int index = Random.Range(0, 10);
        DirtyHand hand = transform.GetChild(index).GetComponent<DirtyHand>();
        EnableHand(hand);
    }
    void EnableHand(DirtyHand hand)
    {
        hand.gameObject.SetActive(true);
    }
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("touchface");
        yield return new WaitForSeconds(4f);
        StartCoroutine(SpawnHand());
    }
    public void PlaySound()
    {
        ac.PlayOneShot(pokeSFX);
    }

}
