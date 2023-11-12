using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [Header("ASSIGNED VIA GAMEPLAY")]
    [SerializeField] private string sceneName;
    [SerializeField] public bool hasRock;
    [SerializeField] public bool placedRock;
    [SerializeField] private bool doorBurnedDown;
    [SerializeField] private GameObject child;
    [SerializeField] private GameObject interactable;

    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private GameObject fireState;
    [SerializeField] private GameObject waterState;
    [SerializeField] private GameObject earthState;
    [SerializeField] private GameObject airState;
    [SerializeField] public string elementalState;                  //public so other scripts have access
    [SerializeField] private GameObject pipeLandingSpot;
    //[SerializeField] private GameObject gameWonPanel;               //temp

    [Header("OTHER SCRIPTS")]
    [SerializeField] private TagManager _tagManager;
    [SerializeField] private UIController _uiController;
    

    // Start is called before the first frame update
    void Start()
    {
        //gameWonPanel.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        placedRock= false;
        doorBurnedDown= false;
    }

    //private void SetInitialElementalState()
    //{
    //    if(sceneName == "levelOne")
    //    {
    //        elementalState = "earth";
    //        earthState.SetActive(true);
    //        airState.SetActive(false);
    //        fireState.SetActive(false);
    //        waterState.SetActive(false);
    //    }
    //    else if (sceneName == "levelTwo")
    //    {
    //        elementalState = "water";
    //        earthState.SetActive(false);
    //        airState.SetActive(false);
    //        fireState.SetActive(false);
    //        waterState.SetActive(true);
    //    }
    //    else if (sceneName == "levelThree")
    //    {
    //        elementalState = "fire";
    //        earthState.SetActive(false);
    //        airState.SetActive(false);
    //        fireState.SetActive(true);
    //        waterState.SetActive(false);
    //    }
    //    else
    //    {
    //        elementalState = "earth";                           //default if something goes wrong, sets state to earth
    //        earthState.SetActive(true);
    //        airState.SetActive(false);
    //        fireState.SetActive(false);
    //        waterState.SetActive(false);
    //    }
    //}

    #region Collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.fireCore))             //firecore switch
        {
            if (elementalState != "fire")                       //if fire NOT active switch to fire
            {
                SetElementalState("fire");
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "fire")                  //if fire active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.waterCore))       //watercore switch
        {
            if (elementalState != "water")                      //if water NOT active switch to water
            {
                SetElementalState("water");
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "water")                 //if water active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.earthCore))       //earthcore switch
        {
            if (elementalState != "earth")                      //if earth NOT active, switch to earth
            {
                SetElementalState("earth");
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "earth")                 //if earth active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.airCore))         //aircore switch
        {
            if (elementalState != "air")                        //if air NOT active, switch to air
            {
                SetElementalState("air");
                other.gameObject.SetActive(false);
            }
            else if (elementalState == "air")                   //if air active do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.pressurePlate))   //pressure plate behavior
        {
            if (hasRock)                                        //can only have rock when earth aligned                          
            {
                //trigger pressure plate
                child.GetComponent<RockBehavior>().attachedToPlayer = false;
                child.GetComponent<RockBehavior>().depositedOnPlate = true;
                child.transform.SetParent(null);
                placedRock = true;
                hasRock = false;
                print("placed rock");
            }
            else                                                //no rock = you shall not pass
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.grate))           //determines if you can pass through the grate
        {
            if(elementalState == "water")
            {
                waterState.GetComponent<BoxCollider>().enabled = false;          //if water, you can pass thru the gate
            }
            else
            {
                return;                                         //no water = you shall not pass
            }
        }      
        else if (other.CompareTag(_tagManager.rock))
        {
            if (!hasRock && elementalState == "earth")          //player can only have one 
            {
                hasRock = true;
                other.transform.SetParent(this.gameObject.transform, false);
                child = other.gameObject;
                other.GetComponent<RockBehavior>().attachedToPlayer = true;
            } 
            else                                                //if hasRock do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.pipe))            //handle pipe collision
        {
            if(elementalState == "water")                       //must be water to pass thru the pipe
            {                                                   //here is likely where you'd play the pipe anim
                this.gameObject.transform.position = pipeLandingSpot.transform.position;
                print("teleported");
            }
            else                                                //if not water do nothing
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.flammable))       //objects that can be set on fire
        {
            if(elementalState == "fire")
            {
                other.gameObject.SetActive(false);              //burning anim instead?
            }
            else
            {
                return;
            }
        }
        else if (other.CompareTag(_tagManager.sceneTransition))
        {
            //scene transition stuff here
            if(sceneName == "levelOne" && elementalState == "water")
            {
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "levelTwo"));
            }
            else if (sceneName == "levelTwo" && elementalState == "fire")
            {
                //door burning anim here, with delay
                //currently set to mainMenu but will change to levelThree
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "mainMenu"));
            }
            else if (sceneName == "levelThree" && elementalState == "air")
            {
                //level three to win? or four
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tagManager.grate))           //determines if you can pass through the grate
        {
            if (elementalState == "water")
            {
                waterState.GetComponent<BoxCollider>().enabled = true;          //if water, you can pass thru the gate
            }
            else
            {
                return;
            }
        }
        //else if (other.CompareTag(_tagManager.pressurePlate) && placedRock)
        //{
        //    placedRock = false; 
        //}
    }
    #endregion


    private void SetElementalState(string element)
    {
        elementalState = element;
        if (element == "fire")
        {
            earthState.SetActive(false);
            airState.SetActive(false);
            fireState.SetActive(true);
            waterState.SetActive(false);
        }
        else if (element == "water")
        {
            earthState.SetActive(false);
            airState.SetActive(false);
            fireState.SetActive(false);
            waterState.SetActive(true);
        }
        else if (element == "earth")
        {
            earthState.SetActive(true);
            airState.SetActive(false);
            fireState.SetActive(false);
            waterState.SetActive(false);
        }
        else if (element == "air")
        {
            earthState.SetActive(false);
            airState.SetActive(true);
            fireState.SetActive(false);
            waterState.SetActive(false);
        }
    }

}
