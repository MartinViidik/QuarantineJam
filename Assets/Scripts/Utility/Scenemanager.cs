﻿using System.Collections;
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
    private int sceneIndex = 2;

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
            ReturnToMenu();
            return;
        }
        sceneIndex = available_scenes[Random.Range(0, available_scenes.Count)];
        available_scenes.Remove(sceneIndex);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }

    public void unloadScene(int index)
    {
        Debug.Log(sceneIndex);
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


    void ReturnToMenu()
    {
        sceneIndex = 2;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        Destroy(GameObject.Find("GameUI"));
        RefreshScenes();
    }

    public void StartGame()
    {
        LoadUI();
        StartTransition();
    }
    
    public void StartTransition()
    {
        StartCoroutine(DelayTransition());
    }

    private IEnumerator DelayTransition()
    {
        Transition.Instance.SetState(0, "in");
        yield return new WaitForSeconds(0.45f);
        unloadScene(sceneIndex);
        loadScene();
        yield return new WaitForSeconds(0.25f);
        Transition.Instance.SetState(1, "out");
    }
}
