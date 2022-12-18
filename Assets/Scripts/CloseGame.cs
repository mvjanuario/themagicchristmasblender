using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    [SerializeField] private GameObject m_creditsPanel;
    public void CloseTheGame()
    {
        Application.Quit();
    }

    public void CloseCreditsPanel()
    {
        m_creditsPanel.gameObject.SetActive(false);
    }
}
