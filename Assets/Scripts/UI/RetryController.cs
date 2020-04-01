using UnityEngine;

public class RetryController : MonoBehaviour
{
    public Canvas canvas;

    public void ReturnToMenu()
    {
        Scenemanager.Instance.ReturnToMenu();
        canvas.gameObject.SetActive(false);
    }

}
