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
    [SerializeField] private GameObject player;
    [SerializeField] private Material[] elementalMaterials = new Material[4];  // earth is [0] water is [1] fire is [2] air is [3]
    [SerializeField] public string elementalState;                  //public so other scripts have access
    [SerializeField] private GameObject pipeLandingSpot;
    //[SerializeField] private GameObject gameWonPanel;               //temp

    [Header("OTHER SCRIPTS")]
    [SerializeField] private TagManager _tagManager;
    [SerializeField] private UIController _uiController;
    

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        //gameWonPanel.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        placedRock= false;
        doorBurnedDown= false;
        SetInitialElementalState();
    }

    private void SetInitialElementalState()
    {
        if (sceneName == "levelOne")
        {
            elementalState = "earth";
            player.GetComponent<Renderer>().material = elementalMaterials[0];
        }
        else if (sceneName == "levelTwo")
        {
            elementalState = "water";
            player.GetComponent<Renderer>().material = elementalMaterials[1];
        }
        else if (sceneName == "levelThree")
        {
            elementalState = "fire";
            player.GetComponent<Renderer>().material = elementalMaterials[2];
        }
        else
        {
            elementalState = "earth";                           //default if something goes wrong, sets state to earth
            player.GetComponent<Renderer>().material = elementalMaterials[0];
        }
    }

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
                print("break 1");
                if (!child.GetComponent<RockBehavior>().depositedOnPlate) //if rock hasn't been placed yet
                {
                    print("break 2");
                    //trigger pressure plate
                    child.GetComponent<RockBehavior>().attachedToPlayer = false;
                    child.GetComponent<RockBehavior>().depositedOnPlate = true;
                    child.GetComponent<RockBehavior>().canPickUp= false;
                    child.transform.SetParent(null);
                    placedRock = true;
                    hasRock = false;
                    print("placed rock");
                    other.GetComponent<PressurePlateBehavior>().PressurePlateTriggered();
                }
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
                //waterState.GetComponent<BoxCollider>().enabled = false;          //if water, you can pass thru the gate
            }
            else
            {
                return;                                         //no water = you shall not pass
            }
        }      
        else if (other.CompareTag(_tagManager.rock))
        {
            GameObject rock = other.gameObject;
            //bool hasPlaced = false;
            if (!hasRock && elementalState == "earth" && rock.GetComponent<RockBehavior>().canPickUp)          //player can only have one 
            {
                //hasPlaced = rock.GetComponent<RockBehavior>().depositedOnPlate;
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
                //waterState.GetComponent<BoxCollider>().enabled = true;          //if water, you can pass thru the gate
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
            player.GetComponent<Renderer>().material = elementalMaterials[2];
        }
        else if (element == "water")
        {
            player.GetComponent<Renderer>().material = elementalMaterials[1];
        }
        else if (element == "earth")
        {
            player.GetComponent<Renderer>().material = elementalMaterials[0];
        }
        else if (element == "air")
        {
            player.GetComponent<Renderer>().material = elementalMaterials[3];
        }
    }

}
