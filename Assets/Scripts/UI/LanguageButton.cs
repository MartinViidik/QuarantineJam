using UnityEngine;
public class LanguageButton : MonoBehaviour
{
    public int value;

    [SerializeField]
    private GameObject controller;
    private MenuSound sound;
    private void Awake()
    {
        sound = controller.GetComponent<MenuSound>();
    }
    public void OnClicked()
    {
        sound.PlayConfirmSound();
        Localisation.LanguageButtonClick(value);
    }
}
