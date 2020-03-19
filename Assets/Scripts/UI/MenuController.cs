using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Scenemanager.Instance.StartGame();
    }
}
