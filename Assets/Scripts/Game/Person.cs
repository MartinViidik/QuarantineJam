﻿using UnityEngine;

public class Person : MonoBehaviour
{
    private enum PersonState
    {
        Stationary,
        Retreating,
        Moving,
        Talking
    }
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private DistanceController controller;
    private Vector3 startPosition;
    private PersonState _state;

    [SerializeField]
    private AudioClip[] grunts;

    private AudioSource ac;
    private void Start()
    {
        startPosition = transform.localPosition;
        ac = GetComponent<AudioSource>();
    }
    private void Update()
    {
        switch (_state)
        {
            case PersonState.Moving:
                {
                    MoveTo(target.transform.localPosition, 2.5f);
                    if (GetDistance(target.transform.localPosition) <= 4f)
                    {
                        _state = PersonState.Talking;
                    }
                }
                break;
            case PersonState.Retreating:
                {
                    MoveTo(startPosition, 3.5f);
                    if(GetDistance(startPosition) <= 0.5f)
                    {
                        _state = PersonState.Moving;
                    }
                }
                break;
            case PersonState.Talking:
                {
                    controller.TalkingTimer();
                    if (GetDistance(target.transform.localPosition) >= 4f)
                    {
                        _state = PersonState.Moving;
                    }
                }
                break;
            case PersonState.Stationary:
                {

                }
                break;
            default:
                _state = PersonState.Stationary;
                break;
        }
    }
    void MoveTo(Vector3 target, float speed)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime * speed);
    }

    float GetDistance(Vector3 target)
    {
        return Vector3.Distance(transform.localPosition, target);
    }

    public void SetRetreating()
    {
        if(_state != PersonState.Retreating)
        {
            Grunt();
            _state = PersonState.Retreating;
            Score.Instance.UpdateScore(5, transform.localPosition, false);
        }
    }
    public void SetMoving()
    {
        _state = PersonState.Moving;
    }
    void Grunt()
    {
        if (!ac.isPlaying)
        {
            int i = Random.Range(0, grunts.Length);
            ac.PlayOneShot(grunts[i], Random.Range(3, 3.25f));
        }
    }
}
