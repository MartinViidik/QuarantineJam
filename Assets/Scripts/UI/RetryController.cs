using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class RetryController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject submitBox;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private GameObject errorMessage;

    [SerializeField]
    private GameObject SubmitButton;

    private MenuSound sound;
    private void Awake()
    {
        sound = GetComponent<MenuSound>();
    }
    public void ReturnToMenu()
    {
        sound.PlayConfirmSound();
        Scenemanager.Instance.ReturnToMenu();
        canvas.gameObject.SetActive(false);
    }
    public void ShowSubmit()
    {
        sound.PlayConfirmSound();
        SetSubmitState(true);
    }
    public void CloseSubmit()
    {
        sound.PlayConfirmSound();
        ClearInput();
        SetSubmitState(false);
    }
    private void SetSubmitState(bool state)
    {
        submitBox.SetActive(state);
    }
    public void SubmitName()
    {
        ClearError();
        if (NameCheck.IsValid(input.text))
        {
            Highscores.AddNewHighscore(input.text, Score.Instance.score);
            CloseSubmit();
            SubmitButton.SetActive(false);
        } else {
            ClearInput();
            UpdateError(NameCheck.SendError());
        }
    }

    private void UpdateError(string error)
    {
        errorMessage.GetComponent<LocaliseText>().UpdateError(error);
    }
    private void ClearError()
    {
        errorMessage.gameObject.GetComponent<TMP_Text>().text = "";
    }
    private void ClearInput()
    {
        input.text = "";
    }
}
