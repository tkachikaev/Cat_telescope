using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private List<string> currentLanguage = new List<string>();
    private string language;

    private void Awake()
    {
        Debug.Log(Application.systemLanguage);
        LanguageSelection();
        LoadingLanguage(language);
    }

    private void LanguageSelection()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            language = PlayerPrefs.GetString("Language");
        }
        else if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Belarusian || Application.systemLanguage == SystemLanguage.Ukrainian)
        {
            language = "ru";
        }
        else
        {
            language = "en";
        }
    }

    private void LoadingLanguage(string language)
    {
        switch (language)
        {
            case "en":
                currentLanguage = English.en_EN;
                break;
            case "ru":
                currentLanguage = Russian.ru_RU;
                break;
            default:
                currentLanguage = English.en_EN;
                break;
        }
    }

    public string GetText(int index)
    {
        return currentLanguage[index];
    }

    public void SaveLanguageEN()
    {
        PlayerPrefs.SetString("Language", "en");
    }
    public void SaveLanguageRU()
    {
        PlayerPrefs.SetString("Language", "ru");
    }
    public void DellPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("Language");
    }
}