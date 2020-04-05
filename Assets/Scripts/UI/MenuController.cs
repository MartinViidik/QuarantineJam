using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private GameObject title;

    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private AudioClip confirmSFX;

    private AudioSource ac;
    public void OnEnable()
    {
        LoadMenu();
    }
    public void PlayGame()
    {
        menuButtons.SetActive(false);
        title.SetActive(false);
        credits.SetActive(false);
        Scenemanager.Instance.StartGame();
    }
    public void LoadMenu()
    {
        menuButtons.SetActive(true);
        title.SetActive(true);
        credits.SetActive(true);
    }
}
