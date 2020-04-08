using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Objective : MonoBehaviour
{
    [SerializeField]
    private TMP_Text objective_text;

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

        objective_text.transform.localScale = new Vector3(0, 0);
        _instance = this;
    }
    public void UpdateObjective(string key)
    {
        objective_text.transform.DOScale(new Vector3(1f, 1f), 0.1f);
        objective_text.text = Localisation.GetLocalisedValue(key);
        StartCoroutine(SetBlank());
    }
    private IEnumerator SetBlank()
    {
        yield return new WaitForSeconds(3);
        objective_text.transform.DOScale(new Vector3(0, 0), 0.1f);
        yield return new WaitForSeconds(0.1f);
        objective_text.text = "";
    }

}
