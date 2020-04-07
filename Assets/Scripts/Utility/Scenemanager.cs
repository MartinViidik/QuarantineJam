using System.Collections;
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

    [SerializeField]
    private List<int> game_scenes = new List<int>();

    [SerializeField]
    private List<int> available_scenes;

    private int sceneIndex = 2;
    private bool gameOver;

    void Start()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (available_scenes.Count == 0)
        {
            RefreshScenes();
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
        if(available_scenes.Count == 0)
        {
            GameOver();
        } else {
            sceneIndex = available_scenes[Random.Range(0, available_scenes.Count)];
            available_scenes.Remove(sceneIndex);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        }
    }
    public void unloadScene(int index)
    {
        if(GameScene.buildIndex <= 0)
        {
            SceneManager.UnloadSceneAsync(index);
        }
    }
    public void LoadUI()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    void RefreshScenes()
    {
        available_scenes = new List<int>(game_scenes);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex > 2)
        {
            GameObject.Find("GameUI").GetComponent<Timer>().SceneChanged();
        }
    }
    public void LoadRetry()
    {
        SceneManager.LoadScene("Retry", LoadSceneMode.Additive);
    }
    public void LoadLeaderboards(bool state)
    {
        if (state)
        {
            SceneManager.LoadSceneAsync("Leaderboards", LoadSceneMode.Additive);
        } else {
            SceneManager.UnloadSceneAsync("Leaderboards");
        }
    }
    public void ReturnToMenu()
    {
        gameOver = false;
        sceneIndex = 2;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        RefreshScenes();
    }
    public void StartGame()
    {
        LoadUI();
        StartTransition();
    }
    void GameOver()
    {
        gameOver = true;
        SceneManager.UnloadSceneAsync(sceneIndex);
        Score.Instance.HideScore(true);
    }
    public void StartTransition()
    {
        StartCoroutine(DelayTransition());
    }
    private IEnumerator DelayTransition()
    {
        Transition.Instance.SetState(0, "in");
        yield return new WaitForSeconds(1f);
        unloadScene(sceneIndex);
        if (!gameOver)
        {
            loadScene();
            yield return new WaitForSeconds(0.25f);
            Transition.Instance.SetState(1, "out");
        }
    }
    public bool IsGameOver()
    {
        return gameOver;
    }
}
