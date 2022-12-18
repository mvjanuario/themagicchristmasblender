using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_coinsText;
    public int m_coin;

    void Start()
    {
        m_coin = 0;
    }

    public void EarnCoin(int coin)
    {
        m_coin += coin;
        m_coinsText.text = "Coins: " + coin;
    }
}
