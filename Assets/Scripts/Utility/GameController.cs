using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    private bool rumble = true;
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
        ac.pitch = pitch;
    }
    public void IncreaseTempo(float amount)
    {
        ac.pitch += amount;
    }
    public void Vibrate()
    {
        if (rumble)
        {
            //Handheld.Vibrate();
            Debug.Log("Vibrating");
        }
    }
    public void SetRumble(bool state)
    {
        rumble = state;
    }
    public void SetHighestScore(float score)
    {
        if (score > CurrentState.highscore)
        {
            CurrentState.highscore = score;
            SaveLoad.Instance.SaveFile();
        }
    }
    public void ClearState()
    {
        CurrentState.highscore = 0;
        CurrentState.face = 0;
        CurrentState.house = 0;
        CurrentState.masks = 0;
        CurrentState.crowds = 0;
        CurrentState.tp = 0;
        SaveLoad.Instance.DeleteFile();
    }
}
