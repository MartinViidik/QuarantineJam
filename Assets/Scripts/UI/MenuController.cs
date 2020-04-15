using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private GameObject title;

    [SerializeField]
    private GameObject settings;

    [SerializeField]
    private GameObject credits;

    private MenuSound sound;

    private void Awake()
    {
        sound = GetComponent<MenuSound>();
        SetScaleToZero(menuButtons);
        SetScaleToZero(title);
        SetScaleToZero(credits);

        StartCoroutine("StartAnimation");
    }

    public void OnEnable()
    {
        LoadMenu();
    }
    public void PlayGame()
    {
        sound.PlayConfirmSound();
        title.SetActive(false);
        credits.SetActive(false);
        Scenemanager.Instance.StartGame();
        ExitAnimation();
    }
    public void Settings()
    {
        sound.PlayConfirmSound();
        settings.SetActive(true);
        SetScaleToZero(settings);
        settings.transform.DOScale(1, 0.2f);
    }
    public void ReturnMenu()
    {
        sound.PlayConfirmSound();
        settings.transform.DOScale(0, 0.2f);
    }
    public void LoadMenu()
    {
        
        sound.PlayConfirmSound();
        menuButtons.SetActive(true);
        title.SetActive(true);
        credits.SetActive(true);
    }
    public void LoadLeaderboards(bool state)
    {
        sound.PlayConfirmSound();
        Scenemanager.Instance.LoadLeaderboards(state);
    }
    void SetScaleToZero(GameObject target)
    {
        target.transform.localScale = new Vector2(0, 0);
    }
    private IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        title.transform.DOScale(0.7f, 0.25f);
        credits.transform.DOScale(0.75f, 0.25f);
        menuButtons.transform.DOScale(1, 0.25f);
    }

    void ExitAnimation()
    {
        menuButtons.transform.DOScale(0, 0.25f);
        credits.transform.DOScale(0, 0.25f);
        title.transform.DOScale(0, 0.25f);
    }
    public void SetQualityLevel(int setting)
    {
        sound.PlayConfirmSound();
        QualitySettings.SetQualityLevel(setting, true);
    }
    public void SetRumble(bool state)
    {
        GameController.Instance.SetRumble(state);
    }
}
