using UnityEngine;

public class TrainingPanelScriptUI : MonoBehaviour
{
    [SerializeField] private TextTranslator _textKey;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_textKey.key))
            gameObject.SetActive(false);
    }

    public void SaveIsClosedPanel()
    {
        PlayerPrefs.SetInt(_textKey.key, 1);
    }
}
