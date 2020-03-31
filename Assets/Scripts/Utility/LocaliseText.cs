using UnityEngine;
using TMPro;

public class LocaliseText : MonoBehaviour
{
    TextMeshProUGUI field;
    public string key;

    private void Start()
    {
        field = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }
    public string GetLocalisation()
    {
        return Localisation.GetLocalisedValue(key);
    }

    void UpdateText()
    {
        field.text = GetLocalisation();
    }

    private void OnEnable()
    {
        Localisation.Click += UpdateText;
    }
}
