using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;
    public SpriteRenderer renderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        SetState(false);
    }
    public void StartOpening()
    {
        open = true;
        SetState(true);
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
        SetState(false);
    }

    public IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(1f);
        if (open)
        {
            Score.Instance.UpdateScore(-10);
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
}
