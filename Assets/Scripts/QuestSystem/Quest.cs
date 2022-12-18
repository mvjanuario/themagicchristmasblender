using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string m_title;
    public string m_description;
    public string m_messageCompleted;
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
