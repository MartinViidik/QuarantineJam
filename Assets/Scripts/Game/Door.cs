﻿using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;
    public SpriteRenderer renderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    public AudioClip openSFX;
    public AudioClip closeSFX;
    private AudioSource ac;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        ac = GetComponent<AudioSource>();
        StartCoroutine("MuteDoors");
        SetState(false);
    }
    public void StartOpening()
    {
        open = true;
        SetState(true);
        ac.PlayOneShot(openSFX, Random.Range(0.5f, 0.75f));
        StartCoroutine(DoorOpen());
    }

    public void SelectDoor()
    {
        Score.Instance.UpdateScore(10);
        CloseDoor();
    }

    void CloseDoor()
    {
        open = false;
        ac.PlayOneShot(closeSFX, Random.Range(0.5f, 0.75f));
        SetState(false);
    }

    public IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(1f);
        if (open)
        {
            Score.Instance.UpdateScore(-10);
            Score.Instance.ShowIndicator(transform.localPosition, false);
            CloseDoor();
        }
    }

    void SetState(bool open)
    {
        if (open)
        {
            renderer.sprite = openSprite;
        } else {
            renderer.sprite = closedSprite;
        }
    }

    IEnumerable MuteDoors()
    {
        yield return new WaitForSeconds(6);
        ac.volume = 0;
    }

}
