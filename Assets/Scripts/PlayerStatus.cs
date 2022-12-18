using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
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
        m_coinsText.text = "Coins: " + m_coin;
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
