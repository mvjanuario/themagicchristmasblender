using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalItem : MonoBehaviour
{
    [SerializeField] private QuestGiver m_questGiver;
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private bool m_observed = false;

    [SerializeField] private GameObject m_goalItemPanel;
    [SerializeField] private TextMeshProUGUI m_goalItemName;
    [SerializeField] private TextMeshProUGUI m_goalItemDescription;

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
            renderer.material.color = new Color(1, 0.972549f, 0.372549f, 1);
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                m_goalItemName.text = m_name;
                m_goalItemDescription.text = m_description;
                m_goalItemPanel.gameObject.SetActive(true);

                if (m_questGiver.GetQuest().m_isActive && m_observed)
                {
                    m_questGiver.GetQuest().m_questGoal.CollectItem();
                    StartCoroutine(FadeItem());
                }
                if (!m_observed)
                    m_observed = true;
            }
        }
        else
        {
            renderer.material.color = standard;
        }
    }

    IEnumerator FadeItem()
    {
        m_goalItemDescription.text = "Collected";
        m_goalItemPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
