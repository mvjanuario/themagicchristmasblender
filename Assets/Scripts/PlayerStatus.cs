using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private SetLanguage m_setLanguage;
    [SerializeField] private TextMeshProUGUI m_coinsText;
    
    private QuestGiver m_questGiver;

    public int m_coin;

    void Start()
    {
        m_coin = 0;
    }

    public void EarnCoin(int coin)
    {
        m_coin += coin;
        if (m_setLanguage.GetLanguage() == "english")
        {
            m_coinsText.text = "Coins: $" + m_coin;
        }
        else if (m_setLanguage.GetLanguage() == "portuguese")
        {
            m_coinsText.text = "Moedas: $" + m_coin;
        }
    }

    public void SetQuestGiver(QuestGiver questgiver)
    {
        m_questGiver = questgiver;
    }

    public QuestGiver GetQuestGiver()
    {
        return m_questGiver;
    }
}
