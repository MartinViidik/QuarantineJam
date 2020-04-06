using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    public int value;
    public void OnClicked()
    {
        Localisation.LanguageButtonClick(value);
    }
}
