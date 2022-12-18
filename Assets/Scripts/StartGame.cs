using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject m_creditsPanel;
    public void OpenCredits()
    {
        m_creditsPanel.gameObject.SetActive(true);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
