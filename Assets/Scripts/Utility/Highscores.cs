﻿using System.Collections;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    public Highscore[] highscoresList;
    static Highscores instance;
    DisplayHighscore highscoreDisplay;

    private void Awake()
    {
        instance = this;
        highscoreDisplay = GetComponent<DisplayHighscore>();
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(LeaderboardKey.webURL + LeaderboardKey.privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload successful");
            DownloadHighscores();
        } else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }
    public void DownloadHighscores()
    {
        StartCoroutine("FetchHighscores");
    }
    IEnumerator FetchHighscores()
    {
        WWW www = new WWW(LeaderboardKey.webURL + LeaderboardKey.publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoreDisplay.OnHighscoresFetched(highscoresList);
        }
        else
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            Debug.Log(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}