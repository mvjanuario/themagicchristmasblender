using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalItem : MonoBehaviour
{
    [SerializeField] private SetLanguage m_setLanguage;
    [SerializeField] private QuestGiver m_questGiver;
    [SerializeField] private string m_nameEnglish;
    [SerializeField] private string m_descriptionEnglish;
    [SerializeField] private string m_namePortuguese;
    [SerializeField] private string m_descriptionPortuguese;
    [SerializeField] private bool m_observed = false;

    [SerializeField] private GameObject m_goalItemPanel;
    [SerializeField] private TextMeshProUGUI m_goalItemName;
    [SerializeField] private TextMeshProUGUI m_goalItemDescription;

    [SerializeField] private GameObject m_currentQuestItemPanel;
    [SerializeField] private TextMeshProUGUI m_currentQuestItem;

    private bool trigged = false;
    private Renderer renderer;
    private Color standard;

    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        standard = renderer.material.color;
    }

    void Update()
    {
        CollectItem();
    }

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
            m_goalItemPanel.gameObject.SetActive(false);
            trigged = false;
        }
    }

    public void CollectItem()
    {
        if (trigged)
        {
            renderer.material.color = new Color(0, 1, 0, 1);
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                if (m_setLanguage.GetLanguage() == "english")
                {
                    m_goalItemName.text = m_nameEnglish;
                    m_goalItemDescription.text = m_descriptionEnglish;
                }
                else if (m_setLanguage.GetLanguage() == "portuguese")
                {
                    m_goalItemName.text = m_namePortuguese;
                    m_goalItemDescription.text = m_descriptionPortuguese;
                }
                
                m_goalItemPanel.gameObject.SetActive(true);

                if (m_questGiver.GetQuest().m_isActive && m_observed)
                {
                    m_questGiver.GetQuest().m_questGoal.CollectItem();
                    StartCoroutine(FadeItem());

                    if (m_setLanguage.GetLanguage() == "english")
                    {
                        m_currentQuestItem.text = "Quest Goals: " + m_questGiver.GetQuest().m_questGoal.currentSubGoals + "/" + m_questGiver.GetQuest().m_questGoal.requiredSubGoals;
                    }
                    else if (m_setLanguage.GetLanguage() == "portuguese")
                    {
                        m_currentQuestItem.text = "Objetivos da Missão: " + m_questGiver.GetQuest().m_questGoal.currentSubGoals + "/" + m_questGiver.GetQuest().m_questGoal.requiredSubGoals;
                    }
                    m_currentQuestItemPanel.gameObject.SetActive(true);
                }
                if (!m_observed)
                    m_observed = true;
            }
        }
        else
        {
            renderer.material.color = standard;
            m_observed = false;
        }
    }

    IEnumerator FadeItem()
    {
        if (m_setLanguage.GetLanguage() == "english")
        {
            m_goalItemDescription.text = "Item has been collected";
        }
        else if (m_setLanguage.GetLanguage() == "portuguese")
        {
            m_goalItemDescription.text = "Item coletado";
        }
        
        m_goalItemPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        this.gameObject.SetActive(false);
    }
}
