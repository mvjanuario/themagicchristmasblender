using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLanguage : MonoBehaviour
{
    [SerializeField] private PlayerStatus m_playerStatus;
    [SerializeField] private TextMeshProUGUI m_coinsText;

    void Start()
    {
        PlayerPrefs.SetString("language", "english");
    }

    public void SetLanguageEnglish()
    {
        PlayerPrefs.SetString("language", "english");
        m_coinsText.text = "Coins: $" + m_playerStatus.m_coin;
    }

    public void SetLanguagePortuguese()
    {
        PlayerPrefs.SetString("language", "portuguese");
        m_coinsText.text = "Moedas: $" + m_playerStatus.m_coin;
    }

    public string GetLanguage()
    {
        return PlayerPrefs.GetString("language");
    }
}
