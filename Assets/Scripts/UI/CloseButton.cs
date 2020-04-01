using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject openWindow;
    public GameObject restoreWindow;

    public void Close()
    {
        openWindow.SetActive(false);
        restoreWindow.SetActive(true);
    }
    public void Open()
    {
        openWindow.SetActive(true);
        restoreWindow.SetActive(false);
    }
}
