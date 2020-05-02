using UnityEngine;

public class ConfirmMenu : MonoBehaviour
{
    public enum ConfirmState { Menu, Quit, Stats };

    [SerializeField]
    GameObject statsScreen;

    ConfirmState state;
    public void SetState(GameObject button)
    {
        if(button.GetComponent<ExitButton>().type == ExitButton.ButtonType.Menu)
        {
            state = ConfirmState.Menu;
        }
        if(button.GetComponent<ExitButton>().type == ExitButton.ButtonType.Quit)
        {
            state = ConfirmState.Quit;
        }
        if (button.GetComponent<ExitButton>().type == ExitButton.ButtonType.Stats)
        {
            state = ConfirmState.Stats;
        }
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
    public void Confirm()
    {
        if(state == ConfirmState.Quit)
        {
            Application.Quit();
        }
        if(state == ConfirmState.Menu)
        {
            Time.timeScale = 1.0f;
            SaveLoad.Instance.SaveFile();
            Scenemanager.Instance.ReturnToMenu();
        }
        if(state == ConfirmState.Stats)
        {
            statsScreen.GetComponent<StatsScreen>().ClearValues();
            CloseWindow();
        }
    }
}
