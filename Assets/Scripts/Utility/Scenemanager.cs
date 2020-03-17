using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private static Scenemanager _instance;
    public static Scenemanager Instance
    {
        get { return _instance; }
    }

    public Scene[] game_scenes;

    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.sceneUnloaded += OnSceneUnloaded;
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

    public void loadScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void unloadScene(int index)
    {
        SceneManager.UnloadSceneAsync(index);
    }

    private void OnSceneUnloaded(Scene current)
    {
        Debug.Log("OnSceneUnloaded: " + current);
    }
}
