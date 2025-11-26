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

    public void ShowLobby()
    {
        SetActivePanel(panelLobby);
    }

    public void ShowIdle()
    {
        SetActivePanel(panelIdle);
    }

    public void ShowInventory()
    {
        SetActivePanel(panelInventory);
    }

    public void ShowShop()
    {
        SetActivePanel(panelShop);
    }

    public void ShowUpgrade()
    {
        SetActivePanel(panelUpgrade);
    }

    private void SetActivePanel(GameObject target)
    {
        panelLobby.SetActive(false);
        panelIdle.SetActive(false);
        panelInventory.SetActive(false);
        panelShop.SetActive(false);
        panelUpgrade.SetActive(false);

        if (target != null)
            target.SetActive(true);
    }
}
