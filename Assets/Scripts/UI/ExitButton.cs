using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public enum ButtonType { Menu, Quit, Stats };

    [SerializeField]
    public ButtonType type;

    [SerializeField]
    private GameObject areYouSure;
    private MenuSound sound;
    private void Awake()
    {
        sound = GetComponent<MenuSound>();
        areYouSure.SetActive(false);
    }
    public void ButtonPressed()
    {
        if(Time.timeScale == 0.0)
        {
            StartCoroutine("OpenUpMenu");
        } else {
            OpenConfirm();
        }
    }

    IEnumerator OpenUpMenu()
    {
        OpenConfirm();
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0.0f;
    }
    void OpenConfirm()
    {
        areYouSure.SetActive(true);
        areYouSure.GetComponent<ConfirmMenu>().SetState(gameObject);
    }
}
