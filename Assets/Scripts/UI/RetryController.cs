using UnityEngine;

public class RetryController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    public void ReturnToMenu()
    {
        Scenemanager.Instance.ReturnToMenu();
        canvas.gameObject.SetActive(false);
    }
}
