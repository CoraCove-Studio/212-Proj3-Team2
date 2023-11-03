using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [Header("ASSIGNED VIA GAMEPLAY")]   
    [SerializeField] public float scaleValue; //public so UIController has access
    [SerializeField] private Vector3 scale;

    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private GameObject fireState;
    [SerializeField] private GameObject waterState;
    [SerializeField] public string elementalState; //public so UIController has access
    [SerializeField] private float sizeRequired;
    [SerializeField] private GameObject gameWonPanel; //temp
    

    // Start is called before the first frame update
    void Start()
    {
        gameWonPanel.SetActive(false);
        scaleValue = 1;
        scale = new Vector3(scaleValue, scaleValue, scaleValue);
        fireState.transform.localScale = scale;
        waterState.transform.localScale = scale;
        elementalState = "water";
    }

    private void FixedUpdate()
    {
        scale = new Vector3(scaleValue, scaleValue, scaleValue);
        fireState.transform.localScale = scale;
        waterState.transform.localScale = scale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireElemental"))
        {
            //if fire active size up
            //if water active size down
            if(elementalState == "fire")
            {
                scaleValue += 0.25f;
                CheckWin();
            }
            else if(elementalState == "water")
            {
                scaleValue = 1;
            }
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("waterElemental"))
        {
            //if water active size up
            //if fire active size down
            if (elementalState == "water")
            {
                scaleValue += 0.25f;
                CheckWin();
            }
            else if (elementalState == "fire")
            {
                scaleValue = 1;
            }
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("fireCore"))
        {
            //if fire active do nothing
            //if water active switch to fire
            if (elementalState == "fire")
            {
                return;
            }
            else if (elementalState == "water")
            {
                elementalState = "fire";
                waterState.SetActive(false);
                fireState.SetActive(true);
            }
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("waterCore"))
        {
            //if fire active switch to fire
            //if water active do nothing
            if (elementalState == "fire")
            {
                elementalState = "water";
                fireState.SetActive(false);
                waterState.SetActive(true);
            }
            else if (elementalState == "water")
            {
                return;
            }
            other.gameObject.SetActive(false);
        }
    }

    private void CheckWin()
    {
        if( scaleValue == sizeRequired)
        {
            Time.timeScale = 0;
            gameWonPanel.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
