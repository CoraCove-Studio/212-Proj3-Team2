using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private Slider size;
    [SerializeField] private Image sizeFill;
    [SerializeField] private Color fireColor;
    [SerializeField] private Color waterColor;

    [Header("OTHER SCRIPTS")] //assigned in inspector
    [SerializeField] private Gameplay _gameplay;
    // Start is called before the first frame update
    void Start()
    {
        //UpdateSlider(_gameplay.scaleValue, _gameplay.elementalState);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //UpdateSlider(_gameplay.scaleValue, _gameplay.elementalState);
        print(_gameplay.elementalState);
    }

    void UpdateSlider(float amount, string state)
    {
        size.value = amount;
        if(state == "fire")
        {
            sizeFill.GetComponent<Image>().color = fireColor;
        }
        else if(state == "water")
        {
            sizeFill.GetComponent<Image>().color = waterColor;
        }
        else
        {
            return;
        }
    }
}
