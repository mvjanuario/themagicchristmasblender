using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType m_goalType;

    public int requiredSubGoals;
    public int currentSubGoals;

    public bool VerifyGoal()
    {
        return (currentSubGoals >= requiredSubGoals);
    }

    public void CollectItem()
    {
        currentSubGoals += 1;
    }
}

public enum GoalType
{
    Answer,
    Collect
}
