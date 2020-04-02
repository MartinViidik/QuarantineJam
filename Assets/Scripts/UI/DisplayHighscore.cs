﻿using System.Collections;
using UnityEngine;
using TMPro;

public class DisplayHighscore : MonoBehaviour
{
    public TMP_Text[] highscoreText;
    public TMP_Text loading;
    Highscores highscoreManager;

    void Start()
    {
        loading.gameObject.SetActive(true);
        highscoreManager = GetComponent<Highscores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresFetched(Highscore[] highscoreList)
    {
        loading.gameObject.SetActive(false);
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if(highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(10);
        }
    }
}
