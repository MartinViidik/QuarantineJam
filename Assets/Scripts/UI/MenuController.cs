using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Scenemanager.Instance.unloadScene(1);
        Scenemanager.Instance.loadScene();
    }
}
