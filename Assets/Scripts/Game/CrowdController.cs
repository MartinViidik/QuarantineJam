using System.Collections;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] crowdPrefabs;

    [SerializeField]
    private Transform[] SpawnPoints;

    private int activeGroupCrowds = 0;

    private void Awake()
    {
        StartCoroutine(InitialDelay());
    }
    private Transform RandomSpawnpoint()
    {
        return SpawnPoints[Random.Range(0, SpawnPoints.Length)];
    }
    private GameObject pickCrowd()
    {
        float RNG = Random.Range(0f, 1f);
        if(RNG > 0.5F)
        {
            //Single person
            return crowdPrefabs[0];
        } else {
            //Group
            activeGroupCrowds++;
            return crowdPrefabs[1];
        }
    }
    void SpawnCrowds()
    {
        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(pickCrowd(), SpawnPoints[i]);
        }
        if(activeGroupCrowds == 0)
        {
            PurgeChildren();
        }
    }
    public void ReduceActiveGroupAmount()
    {
        activeGroupCrowds--;
        if(activeGroupCrowds == 0)
        {
            StartCoroutine("CrowdsCoroutine");
        }
    }
    public void PurgeChildren()
    {
        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            if(SpawnPoints[i].childCount > 0)
            {
                SpawnPoints[i].GetChild(0).GetComponent<Crowd>().Disappear();
            }
        }
    }
    private IEnumerator CrowdsCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        PurgeChildren();
        yield return new WaitForSeconds(2f);
        SpawnCrowds();
    }
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Objective.Instance.UpdateObjective("crowds");
        yield return new WaitForSeconds(4f);
        SpawnCrowds();
    }

}
