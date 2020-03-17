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
        renderer.color = Color.red;
        StartCoroutine(DoorOpen());
        open = true;
    }

    public void SelectDoor()
    {
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
        CloseDoor();
        Debug.Log("Take points");
    }
}
