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
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateObjective(string newObjective)
    {
        objective_text.text = newObjective;
        StartCoroutine(SetBlank());
    }

    private IEnumerator SetBlank()
    {
        yield return new WaitForSeconds(3);
        objective_text.text = "";
    }

}
