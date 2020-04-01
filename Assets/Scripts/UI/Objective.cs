using System.Collections;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public TMP_Text objective_text;

    private static Objective _instance;
    public static Objective Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
    }

    public void UpdateObjective(string key)
    {
        objective_text.text = Localisation.GetLocalisedValue(key);
        StartCoroutine(SetBlank());
    }

    private IEnumerator SetBlank()
    {
        yield return new WaitForSeconds(3);
        objective_text.text = "";
    }

}
