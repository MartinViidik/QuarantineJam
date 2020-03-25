﻿using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get { return _instance; }
    }
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

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        ac = GetComponent<AudioSource>();
    }

    public void SetTempo(float pitch)
    {

    }
}
