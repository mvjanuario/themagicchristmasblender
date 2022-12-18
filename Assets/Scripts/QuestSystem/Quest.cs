using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string m_titleEnglish;
    public string m_descriptionEnglish;
    public string m_messageCompletedEnglish;
    public string m_titlePortuguese;
    public string m_descriptionPortuguese;
    public string m_messageCompletedPortuguese;
    public int m_coinReward;

    public bool m_isActive;
    public QuestGoal m_questGoal;

    public void AcceptQuest()
    {
        m_isActive = true;
    }

    public void CompleteQuest()
    {
        m_isActive = false;
    }
}
