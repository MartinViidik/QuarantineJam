using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuButtons;
    public GameObject title;
    public GameObject credits;

    public AudioClip confirmSFX;
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
