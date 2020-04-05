using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject openWindow;

    [SerializeField]
    private GameObject restoreWindow;

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
