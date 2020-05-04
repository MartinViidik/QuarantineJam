using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    [SerializeField]
    private Button selectedLanguage;

    public void ChangeSettings()
    {
        if(selectedLanguage != null)
        {
            selectedLanguage.GetComponent<Button>().interactable = true;
        }
    }
    public void GetButton(Button button)
    {
        ChangeSettings();
        selectedLanguage = button;
    }
}
