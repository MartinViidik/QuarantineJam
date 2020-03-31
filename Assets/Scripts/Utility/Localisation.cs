using System.Collections.Generic;
using UnityEngine;

public class Localisation : MonoBehaviour
{
    public enum Language
    {
        English,
        Estonian
    }
    public static Language language = Language.Estonian;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedEE;

    public delegate void ButtonClick();
    public static event ButtonClick Click;

    public static bool isInit;
    public static void init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedEE = csvLoader.GetDictionaryValues("ee");

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
        }
        return value;
    }
    public static void UpdateLanguage(Language newLanguage)
    {
        language = newLanguage;
        Click();
    }

}
