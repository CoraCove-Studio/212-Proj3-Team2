using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private TMP_Text coinCount;
    [SerializeField] private TMP_Text keyCount;
    [SerializeField] private Image[] elementalIcons;            //0 is earth, 1 is water, 2 is fire, 3 is air
    [SerializeField] private GameObject pausePanel;


    [Header("ASSIGNED VIA GAMEPLAY")]
    [SerializeField] private Image activeIcon;

    [Header("OTHER SCRIPTS")]
    [SerializeField] private Gameplay _gameplay;

    private void Start()
    {
        elementalIcons = new Image[4];
        pausePanel.SetActive(false);
        //ChangeElementalIcon(_gameplay.elementalState);
    }

    public void ChangeElementalIcon(string state)
    {
        switch (state)
        {
            case "earth":
                activeIcon = elementalIcons[0];
                break;
            case "water":
                activeIcon = elementalIcons[1];
                break;
            case "fire":
                activeIcon = elementalIcons[2];
                break;
            case "air":
                activeIcon = elementalIcons[3];
                break;
            default:
                activeIcon = elementalIcons[0];
                break;
        }
    }

    public void UpdateCoinCount(int coins)
    {
        coinCount.text = "x" + coins.ToString();
    }

    public void UpdateKeyCount(int keys)
    {
        keyCount.text = "x" + keys.ToString();
    }

    public void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
    }

    public void DeactivatePauseMenu()
    {
        pausePanel.SetActive(false);
    }
}
