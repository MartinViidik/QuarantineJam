using System.Collections.Generic;
using UnityEngine;

public class Localisation : MonoBehaviour
{
    public enum Language
    {
        English = 0,
        Estonian = 1,
        Swedish = 2,
        Dutch = 3,
        Japanese = 4
    }
    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedEE;
    private static Dictionary<string, string> localisedSE;
    private static Dictionary<string, string> localisedNL;
    private static Dictionary<string, string> localisedJP;

    public delegate void ButtonClick();
    public static event ButtonClick Click;

    public static bool isInit;
    public static void init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedEE = csvLoader.GetDictionaryValues("ee");
        localisedSE = csvLoader.GetDictionaryValues("se");
        localisedNL = csvLoader.GetDictionaryValues("nl");
        localisedJP = csvLoader.GetDictionaryValues("jp");

        isInit = true;
    }
    public static string GetLocalisedValue(string key)
    {
        if (!isInit){ init(); }

        string value = key;
        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Estonian:
                localisedEE.TryGetValue(key, out value);
                break;
            case Language.Swedish:
                localisedSE.TryGetValue(key, out value);
                break;
            case Language.Dutch:
                localisedNL.TryGetValue(key, out value);
                break;
            case Language.Japanese:
                localisedJP.TryGetValue(key, out value);
                break;
        }
        return value;
    }
    public static void UpdateLanguage(Language newLanguage)
    {
        language = newLanguage;
        Click();
    }
    public static void LanguageButtonClick(int value)
    {
        UpdateLanguage((Language)value);
    }

}
