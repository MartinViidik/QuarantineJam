using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private TMP_Text face;
    [SerializeField]
    private TMP_Text crowds;
    [SerializeField]
    private TMP_Text tp;
    [SerializeField]
    private TMP_Text house;
    [SerializeField]
    private TMP_Text masks;

    private void OnEnable()
    {
        SetValues();
    }
    void SetValues()
    {
        score.text = CurrentState.highscore.ToString();
        face.text = CurrentState.face.ToString();
        crowds.text = CurrentState.face.ToString();
        tp.text = CurrentState.tp.ToString();
        house.text = CurrentState.house.ToString();
        masks.text = CurrentState.masks.ToString();
    }
    public void ClearValues()
    {
        GameController.Instance.ClearState();
        SetValues();
    }
}
