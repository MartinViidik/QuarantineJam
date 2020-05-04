using UnityEngine;
using TMPro;

public class LocaliseText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI field;

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
    public void UpdateText()
    {
        field.text = GetLocalisation();
    }
    private void OnEnable()
    {
        Localisation.Click += UpdateText;
    }
    public void UpdateError(string error)
    {
        key = error;
        UpdateText();
    }
}
