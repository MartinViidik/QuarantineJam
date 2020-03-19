﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyHandController : MonoBehaviour
{
    public GameObject dirtyHand;
    public GameObject target;

    private void Awake()
    {
        for(int i = 0; i <= 10; i++)
        {
            GameObject _dirtyHand = Instantiate(dirtyHand, transform);
            _dirtyHand.SetActive(false);
        }

        StartCoroutine(InitialDelay());
    }

    public IEnumerator SpawnHand()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            GetHand();
        }
    }

    void GetHand()
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
        Objective.Instance.UpdateObjective("Don't touch your face!");
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnHand());
    }

}
