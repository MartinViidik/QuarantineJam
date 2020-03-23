﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public Person[] people;
    bool timer;
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
        if (timer)
        {
            StartCoroutine(TalkingDelay());
        } else {
            return;
        }
    }

    private IEnumerator TalkingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Score.Instance.UpdateScore(-25);
        timer = false;
    }
}