using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("화면 패널들")]
    public GameObject panelLobby;
    public GameObject panelIdle;
    public GameObject panelInventory;
    public GameObject panelShop;
    public GameObject panelUpgrade;

    [Header("Default Panel")]
    public GameObject defaultPanel;

    public void Show(GameObject panel)
    {
        if (panelLobby) panelLobby.SetActive(false);
        if (panelIdle) panelIdle.SetActive(false);
        if (panelInventory) panelInventory.SetActive(false);
        if (panelShop) panelShop.SetActive(false);
        if (panelUpgrade) panelUpgrade.SetActive(false);

        panel?.SetActive(true);
    }

    public void ShowDefault()
    {
        Show(defaultPanel);
    }
}