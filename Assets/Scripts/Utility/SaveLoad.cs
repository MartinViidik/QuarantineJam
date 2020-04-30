using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private static SaveLoad _instance;
    public static SaveLoad Instance
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
    }
    void Start()
    {
        LoadFile();
    }
    public void SaveFile()
    {
        Debug.Log("Saving stats");
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameState data = new GameState(CurrentState.highscore, CurrentState.face, CurrentState.crowds, CurrentState.tp, CurrentState.house, CurrentState.masks);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameState data = (GameState)bf.Deserialize(file);
        SetState(data);
        file.Close();
    }

    void SetState(GameState data)
    {
        CurrentState.highscore = data.highscore;
        CurrentState.face = data.face;
        CurrentState.crowds = data.crowds;
        CurrentState.tp = data.tp;
        CurrentState.house = data.house;
        CurrentState.masks = data.masks;
    }

}
