using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Scenemanager.Instance.unloadScene(2);
        Scenemanager.Instance.loadScene();
        Scenemanager.Instance.LoadUI();
    }
}
