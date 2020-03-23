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

    public AudioClip confirmSFX;
    private AudioSource ac;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        ac = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        LoadMenu(state);
    }

    public void PlayGame()
    {
        Scenemanager.Instance.StartGame();
        PlaySound();
        SetButtons(false);
    }
    public void Retry()
    {
        Scenemanager.Instance.Retry();
        PlaySound();
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

    void PlaySound()
    {
        ac.PlayOneShot(confirmSFX);
    }
}
