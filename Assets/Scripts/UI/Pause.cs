using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausedGraphic;
    public void PauseGame()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            pausedGraphic.SetActive(true);
        } else {
            Time.timeScale = 1.0f;
            pausedGraphic.SetActive(false);
        }
    }
}
