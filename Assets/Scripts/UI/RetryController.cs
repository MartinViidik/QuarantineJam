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
    private TMP_Text errorMessage;

    [SerializeField]
    private GameObject SubmitButton;
    public void ReturnToMenu()
    {
        Scenemanager.Instance.ReturnToMenu();
        canvas.gameObject.SetActive(false);
    }
    public void ShowSubmit()
    {
        SetSubmitState(true);
    }
    public void CloseSubmit()
    {
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
            Debug.Log("Successful");
            CloseSubmit();
            SubmitButton.SetActive(false);
        } else {
            ClearInput();
            UpdateError(NameCheck.SendError());
        }
    }

    private void UpdateError(string error)
    {
        errorMessage.text = error;
    }
    private void ClearError()
    {
        errorMessage.text = "";
    }
    private void ClearInput()
    {
        input.text = "";
    }
}
