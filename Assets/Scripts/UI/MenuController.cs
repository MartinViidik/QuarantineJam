using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private GameObject title;

    [SerializeField]
    private GameObject credits;

    private MenuSound sound;

    private void Awake()
    {
        sound = GetComponent<MenuSound>();
    }

    public void OnEnable()
    {
        LoadMenu();
    }
    public void PlayGame()
    {
        sound.PlayConfirmSound();
        menuButtons.SetActive(false);
        title.SetActive(false);
        credits.SetActive(false);
        Scenemanager.Instance.StartGame();
    }
    public void LoadMenu()
    {
        sound.PlayConfirmSound();
        menuButtons.SetActive(true);
        title.SetActive(true);
        credits.SetActive(true);
    }
    public void LoadLeaderboards(bool state)
    {
        sound.PlayConfirmSound();
        Scenemanager.Instance.LoadLeaderboards(state);
    }
}
