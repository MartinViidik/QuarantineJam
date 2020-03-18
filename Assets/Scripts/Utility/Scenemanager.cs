using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private static Scenemanager _instance;
    private Scene GameScene;
    public static Scenemanager Instance
    {
        get { return _instance; }
    }

    public List<int> game_scenes = new List<int>();
    public List<int> available_scenes;
    private int sceneIndex = 0;

    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (available_scenes.Count == 0)
        {
            available_scenes = new List<int>(game_scenes);
        }
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
        if(sceneIndex != 0)
        {
            unloadScene(sceneIndex);
        }
        if(available_scenes.Count == 0)
        {
            ReturnToMenu();
            return;
        }
        sceneIndex = available_scenes[Random.Range(0, available_scenes.Count)];
        available_scenes.Remove(sceneIndex);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        Background.Instance.StartTransition();
    }

    public void unloadScene(int index)
    {
        if(GameScene.buildIndex <= 0)
        {
            SceneManager.UnloadSceneAsync(index);
        } else {
            SceneManager.UnloadSceneAsync(GameScene.buildIndex);
        }
        Background.Instance.StartTransition();
    }

    public void LoadUI()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.buildIndex);
        if(scene.buildIndex >= 1)
        {
            GameObject.Find("GameUI").GetComponent<Timer>().SceneChanged();
        }
    }

    void ReturnToMenu()
    {
        sceneIndex = 0;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Destroy(GameObject.Find("GameUI"));
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        available_scenes = new List<int>(game_scenes);
    }
}
