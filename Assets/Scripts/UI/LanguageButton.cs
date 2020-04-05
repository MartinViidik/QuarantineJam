using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    public int value { get; private set; }
    public void OnClicked()
    {
        Localisation.LanguageButtonClick(value);
    }
}
