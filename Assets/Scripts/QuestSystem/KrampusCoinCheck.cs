using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KrampusCoinCheck : MonoBehaviour
{
    [SerializeField] private SetLanguage m_setLanguage;
    [SerializeField] private PlayerStatus m_playerStatus;
    [SerializeField] private string m_nameEnglish;
    [SerializeField] private string m_descriptionEnglish;
    [SerializeField] private string m_messageCompletedEnglish;
    [SerializeField] private string m_namePortuguese;
    [SerializeField] private string m_descriptionPortuguese;
    [SerializeField] private string m_messageCompletedPortuguese;
    [SerializeField] private bool m_observed = false;

    [SerializeField] private GameObject m_questPanel;
    [SerializeField] private TextMeshProUGUI m_questTitle;
    [SerializeField] private TextMeshProUGUI m_questDescription;
    [SerializeField] private int m_goalCoins;

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
        CheckCoinAmount();
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
            m_questPanel.gameObject.SetActive(false);
            trigged = false;
        }
    }

    public void CheckCoinAmount()
    {
        if (trigged)
        {
            renderer.material.color = new Color(1, 0, 0, 1);
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                if ((m_playerStatus.m_coin >= m_goalCoins) && m_observed)
                {
                    if (m_setLanguage.GetLanguage() == "english")
                    {
                        m_questTitle.text = m_nameEnglish;
                        m_questDescription.text = m_messageCompletedEnglish;
                    }
                    else if (m_setLanguage.GetLanguage() == "portuguese")
                    {
                        m_questTitle.text = m_namePortuguese;
                        m_questDescription.text = m_messageCompletedPortuguese;
                    }
                    SceneManager.LoadScene(1);
                }
                else
                {
                    if (m_setLanguage.GetLanguage() == "english")
                    {
                        m_questTitle.text = m_nameEnglish;
                        m_questDescription.text = m_descriptionEnglish;
                    }
                    else if (m_setLanguage.GetLanguage() == "portuguese")
                    {
                        m_questTitle.text = m_namePortuguese;
                        m_questDescription.text = m_descriptionPortuguese;
                    }
                }
                m_questPanel.gameObject.SetActive(true);
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
}
