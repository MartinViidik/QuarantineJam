using UnityEngine;
using UnityEngine.UI;
public class LanguageButton : MonoBehaviour
{
    public int value;

    [SerializeField]
    private GameObject controller;
    private MenuSound sound;

    [SerializeField]
    private LanguageSettings settings;
    private void Awake()
    {
        sound = controller.GetComponent<MenuSound>();
    }
    public void OnClicked()
    {
        GetComponent<Button>().interactable = false;
        settings.GetButton(gameObject.GetComponent<Button>());
        sound.PlayConfirmSound();
        Localisation.LanguageButtonClick(value);
    }
}
