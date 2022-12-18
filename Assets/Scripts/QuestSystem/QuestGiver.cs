using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest m_quest;
    [SerializeField] private GameObject m_questPanel;
    [SerializeField] private TextMeshProUGUI m_questTitle;
    [SerializeField] private TextMeshProUGUI m_questDescription;

    [SerializeField] private GameObject m_mainPanel;
    [SerializeField] private TextMeshProUGUI m_currentQuest;

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
                m_questTitle.text = m_quest.m_title;
                if (m_quest.m_questGoal.VerifyGoal())
                {
                    m_questDescription.text = m_quest.m_messageCompleted;
                    m_quest.CompleteQuest();
                    m_mainPanel.gameObject.SetActive(false);
                }
                else
                {
                    m_questDescription.text = m_quest.m_description;
                    m_quest.AcceptQuest();

                    m_currentQuest.text = "Current Quest: " + m_quest.m_title;
                    m_mainPanel.gameObject.SetActive(true);
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
