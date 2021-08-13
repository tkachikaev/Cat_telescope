
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationText : MonoBehaviour
{
    #region Unity inspector dropdown
    public enum TextSetting { StaticText, Setting, Dialog };
    public TextSetting textSetting;
    #endregion

    public int indexText;
    public Localization localization;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        if (textSetting.HasFlag(TextSetting.StaticText))
        {
            Debug.Log("StaticText");
        }
        if (textSetting == TextSetting.Setting)
        {
            Debug.Log("Setting");
        }
        text.text = localization.GetText(indexText);
    }

}
