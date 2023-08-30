using TMPro;
using UnityEngine;

public class ChangeLanguageController : MonoBehaviour
{
    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
            LangsList.SetLanguage(0);
        if (Application.systemLanguage == SystemLanguage.English)
            LangsList.SetLanguage(1);
        if (Application.systemLanguage == SystemLanguage.Turkish)
            LangsList.SetLanguage(2);

    }

    public void ChangeLang (TMP_Dropdown tmp)
    {
        LangsList.SetLanguage(tmp.value, true);
    }
}
