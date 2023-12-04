using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //[Header("ASSIGNED IN INSPECTOR")]
    //[SerializeField] private Slider size;
    //[SerializeField] private Image sizeFill;
    //[SerializeField] private Color fireColor;
    //[SerializeField] private Color waterColor;

    //[Header("OTHER SCRIPTS")] //assigned in inspector
    //[SerializeField] private Gameplay _gameplay;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    UpdateSlider(_gameplay.scaleValue, _gameplay.elementalState);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    UpdateSlider(_gameplay.scaleValue, _gameplay.elementalState);
    //    //print(_gameplay.elementalState);
    //}

    //void UpdateSlider(float amount, string state)
    //{
    //    size.value = amount;
    //    if(state == "fire")
    //    {
    //        sizeFill.GetComponent<Image>().color = fireColor;
    //    }
    //    else if(state == "water")
    //    {
    //        sizeFill.GetComponent<Image>().color = waterColor;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

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
        activeIcon.gameObject.SetActive(true);
    }

    private void Update()
    {
        ChangeElementalIcon(_gameplay.elementalState);

        if (_gameplay.elementalState == "earth")
        {
            activeIcon = elementalIcons[0];
            elementalIcons[1].gameObject.SetActive(false);
            elementalIcons[2].gameObject.SetActive(false);
            elementalIcons[3].gameObject.SetActive(false);
        }

        else if (_gameplay.elementalState == "water")
        {
            activeIcon = elementalIcons[1];
            elementalIcons[0].gameObject.SetActive(false);
            elementalIcons[2].gameObject.SetActive(false);
            elementalIcons[3].gameObject.SetActive(false);
        }

        else if (_gameplay.elementalState == "fire")
        {
            activeIcon = elementalIcons[2];
            elementalIcons[0].gameObject.SetActive(false);
            elementalIcons[1].gameObject.SetActive(false);
            elementalIcons[3].gameObject.SetActive(false);
        }

        else if (_gameplay.elementalState == "air")
        {
            activeIcon = elementalIcons[3];
            elementalIcons[0].gameObject.SetActive(false);
            elementalIcons[1].gameObject.SetActive(false);
            elementalIcons[2].gameObject.SetActive(false);
        }
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
