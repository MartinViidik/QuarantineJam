using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject play;
    public GameObject retry;

    public string state = "mainmenu";

    private static MenuController _instance;
    public static MenuController Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnEnable()
    {
        LoadMenu(state);
    }

    public void PlayGame()
    {
        Scenemanager.Instance.StartGame();
        SetButtons(false);
    }
    public void Retry()
    {
        Scenemanager.Instance.Retry();
        SetButtons(false);
    }

    public void ToMenu()
    {
        Scenemanager.Instance.ReturnToMenu();
        SetButtons(false);
    }

    public void LoadMenu(string state)
    {
        if(state == "mainmenu")
        {
            play.SetActive(true);
            retry.SetActive(false);
        }
        if(state == "endgame")
        {
            play.SetActive(false);
            retry.SetActive(true);
        }
    }

    void SetButtons(bool state)
    {
        play.SetActive(state);
        retry.SetActive(state);
    }
}
