using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject openWindow;

    [SerializeField]
    private GameObject restoreWindow;

    [SerializeField]
    private GameObject controller;
    private MenuSound sound;

    private void Awake()
    {
        sound = controller.GetComponent<MenuSound>();
    }

    public void Close()
    {
        openWindow.SetActive(false);
        restoreWindow.SetActive(true);
        sound.PlayConfirmSound();
    }
    public void Open()
    {
        openWindow.SetActive(true);
        restoreWindow.SetActive(false);
        sound.PlayConfirmSound();
    }
}
