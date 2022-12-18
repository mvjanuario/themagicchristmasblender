using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private SetLanguage m_setLanguage;
    [SerializeField] private PlayerStatus m_playerStatus;
    [SerializeField] private Quest m_quest;
    [SerializeField] private GameObject m_questPanel;
    [SerializeField] private TextMeshProUGUI m_questTitle;
    [SerializeField] private TextMeshProUGUI m_questDescription;

    [SerializeField] private GameObject m_currentQuestPanel;
    [SerializeField] private TextMeshProUGUI m_currentQuest;

    [SerializeField] private GameObject m_currentQuestItemPanel;
    [SerializeField] private TextMeshProUGUI m_currentQuestItem;

    private bool trigged = false;
    private Renderer renderer;
    private Color standard;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trigged = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trigged = false;
            m_questPanel.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        standard = renderer.material.color;
    }

    void Update()
    {
        VerifyTrigged();
    }

    private void VerifyTrigged()
    {
        if (trigged)
        {
            renderer.material.color = new Color(1, 0.972549f, 0.372549f, 1);

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                if (m_setLanguage.GetLanguage() == "english")
                {
                    m_questTitle.text = m_quest.m_titleEnglish;
                }
                else if (m_setLanguage.GetLanguage() == "portuguese")
                {
                    m_questTitle.text = m_quest.m_titlePortuguese;
                }
                if (m_quest.m_questGoal.VerifyGoal())
                {
                    if (m_quest.m_isActive)
                        m_playerStatus.EarnCoin(m_quest.m_coinReward);

                    if (m_setLanguage.GetLanguage() == "english")
                    {
                        m_questDescription.text = m_quest.m_messageCompletedEnglish;
                    }
                    else if (m_setLanguage.GetLanguage() == "portuguese")
                    {
                        m_questDescription.text = m_quest.m_messageCompletedPortuguese;
                    }
                    
                    m_quest.CompleteQuest();
                    m_currentQuestPanel.gameObject.SetActive(false);
                    m_currentQuestItemPanel.gameObject.SetActive(false);
                }
                else
                {
                    m_quest.AcceptQuest();

                    if (m_setLanguage.GetLanguage() == "english")
                    {
                        m_questDescription.text = m_quest.m_descriptionEnglish;
                        m_currentQuest.text = "Current Quest: " + m_quest.m_titleEnglish;
                        m_currentQuestItem.text = "Quest Goals: " + m_quest.m_questGoal.currentSubGoals + "/" + m_quest.m_questGoal.requiredSubGoals;
                    }
                    else if (m_setLanguage.GetLanguage() == "portuguese")
                    {
                        m_questDescription.text = m_quest.m_descriptionPortuguese;
                        m_currentQuest.text = "Missão Atual: " + m_quest.m_titlePortuguese;
                        m_currentQuestItem.text = "Objetivos da Missão: " + m_quest.m_questGoal.currentSubGoals + "/" + m_quest.m_questGoal.requiredSubGoals;
                    }

                    
                    m_currentQuestPanel.gameObject.SetActive(true);
                    m_currentQuestItemPanel.gameObject.SetActive(true);
                }

                if (!m_questPanel.activeSelf)
                {
                    m_questPanel.gameObject.SetActive(true);
                }
                else
                {
                    m_questPanel.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            renderer.material.color = standard;
        }
    }

    public Quest GetQuest()
    {
        return m_quest;
    }
}
