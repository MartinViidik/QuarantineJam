using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open;
    public SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void StartOpening()
    {
        open = true;
        renderer.color = Color.red;
        StartCoroutine(DoorOpen());
    }

    public void SelectDoor()
    {
        Score.Instance.UpdateScore(10);
        CloseDoor();
    }

    void CloseDoor()
    {
        renderer.color = Color.white;
        open = false;
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
}
