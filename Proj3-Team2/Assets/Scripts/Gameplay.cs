using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [Header("ASSIGNED VIA GAMEPLAY")]
    //[SerializeField] public float scaleValue; //public so UIController has access
    //[SerializeField] private Vector3 scale;
    [SerializeField] private string sceneName;
    [SerializeField] private bool hasRock;

    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private GameObject fireState;
    [SerializeField] private GameObject waterState;
    [SerializeField] private GameObject earthState;
    [SerializeField] private GameObject airState;
    [SerializeField] public string elementalState; //public so UIController has access
    [SerializeField] private float sizeRequired;
    [SerializeField] private GameObject gameWonPanel; //temp
    

    // Start is called before the first frame update
    void Start()
    {
        gameWonPanel.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        SetInitialElementalState();
        
    }

    private void FixedUpdate()
    {

    }

    private void SetInitialElementalState()
    {
        if(sceneName == "levelOne")
        {
            elementalState = "earth";
            earthState.SetActive(true);
            airState.SetActive(false);
            fireState.SetActive(false);
            waterState.SetActive(false);
        }
        else if (sceneName == "levelTwo")
        {
            elementalState = "water";
            earthState.SetActive(false);
            airState.SetActive(false);
            fireState.SetActive(false);
            waterState.SetActive(true);
        }
        else if (sceneName == "levelThree")
        {
            elementalState = "fire";
            earthState.SetActive(false);
            airState.SetActive(false);
            fireState.SetActive(true);
            waterState.SetActive(false);
        }
        else
        {
            elementalState = "earth"; //default if something goes wrong, sets state to earth
            earthState.SetActive(true);
            airState.SetActive(false);
            fireState.SetActive(false);
            waterState.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireCore"))                   //firecore switch
        {
            if (elementalState != "fire")                   //if fire NOT active switch to fire
            {
                elementalState = "fire";
                earthState.SetActive(false);
                airState.SetActive(false);
                fireState.SetActive(true);
                waterState.SetActive(false);
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "fire")               //if fire active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag("waterCore"))             //watercore switch
        {
            if (elementalState != "water")                  //if water NOT active switch to water
            {
                elementalState = "water";
                earthState.SetActive(false);
                airState.SetActive(false);
                fireState.SetActive(false);
                waterState.SetActive(true);
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "water")             //if water active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag("earthCore"))             //earthcore switch
        {
            if (elementalState != "earth")                  //if earth NOT active, switch to earth
            {
                elementalState = "earth";
                earthState.SetActive(true);
                airState.SetActive(false);
                fireState.SetActive(false);
                waterState.SetActive(false);
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "earth")             //if earth active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag("airCore"))               //aircore switch
        {
            if (elementalState != "air")                    //if air NOT active, switch to air
            {
                elementalState = "air";
                earthState.SetActive(false);
                airState.SetActive(true);
                fireState.SetActive(false);
                waterState.SetActive(false);
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "air")               //if air active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag("pressurePlate"))         //pressure plate behavior
        {
            if (hasRock)                                    //can only have rock when earth aligned                          
            {
                //trigger pressure plate
                //enable 'press e to place rock'
            }
            else                                            //no rock = you shall not pass
            {
                //does nothing
            }
        }
        else if (other.CompareTag("grate"))                 //determines if you can pass through the grate
        {
            if(elementalState == "water")
            {
                //enable press e to 
            }
        }             
    }

    //private void CheckWin()
    //{
    //    if( scaleValue == sizeRequired)
    //    {
    //        Time.timeScale = 0;
    //        gameWonPanel.SetActive(true);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
