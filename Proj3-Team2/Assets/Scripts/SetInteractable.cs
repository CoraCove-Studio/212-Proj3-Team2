using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetInteractable : MonoBehaviour
{
    [Header("VALUES ASSIGNED ON RUNTIME")]
    [SerializeField] public GameObject interactable;   //assigned by script based on trigger colliders, should not be assigned in inspector. 

    [Header("UI COMPONENTS")]
    [SerializeField] private GameObject interactPanel; //assigned in inspector
    [SerializeField] private TMP_Text interactText;

    [Header("KEY CODES")]
    [SerializeField] public KeyCode interact; //assigned in inspector

    [Header("OTHER SCRIPTS")]
    [SerializeField] private TagManager _tagManager;
    [SerializeField] private Gameplay _gameplay;

    [Header("TEXT STRINGS")]
    [SerializeField] private string coreInteract;
    [SerializeField] private string rockInteract;
    [SerializeField] private string plateInteract;
    [SerializeField] private string pipeInteract;

    // Start is called before the first frame update
    void Start()
    {
        interactPanel.SetActive(false); //guarantees interact panel is hidden by default
        coreInteract = "PRESS E TO CHANGE YOUR ELEMENT";
        rockInteract = "PRESS E TO PICK UP THIS ROCK";
        plateInteract = "PRESS E TO PLACE THE ROCK";
        pipeInteract = "PRESS E TO TRAVEL THROUGH PIPE";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.rock))
        {
            if (other.GetComponent<RockBehavior>().canPickUp)
            {
                ShowInteractMenu();
                SetInteractableObject(other.gameObject);
                interactText.text = rockInteract;
            }
        }
        else if (other.CompareTag(_tagManager.pressurePlate) || other.CompareTag(_tagManager.weightedPlate))
        {
            if (_gameplay.hasRock)
            {
                ShowInteractMenu();
                SetInteractableObject(other.gameObject);
                interactText.text = plateInteract;
            }
        }
        else if (other.CompareTag(_tagManager.fireCore) || other.CompareTag(_tagManager.waterCore) || other.CompareTag(_tagManager.earthCore) || other.CompareTag(_tagManager.airCore))
        {
            ShowInteractMenu();
            SetInteractableObject(other.gameObject);
            interactText.text = coreInteract;
        }
        else if (other.CompareTag(_tagManager.pipe))
        {
            if(_gameplay.elementalState == "water")
            {
                ShowInteractMenu();
                SetInteractableObject(other.gameObject);
                interactText.text = pipeInteract;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tagManager.rock) || other.CompareTag(_tagManager.pressurePlate) || other.CompareTag(_tagManager.weightedPlate) || other.CompareTag(_tagManager.fireCore) || other.CompareTag(_tagManager.waterCore) || other.CompareTag(_tagManager.earthCore) || other.CompareTag(_tagManager.airCore))
        {
            HideInteractMenu();
            SetInteractableObject(null);
        }
    }

    private void SetInteractableObject(GameObject target)
    {
        interactable = target;
        print(interactable + " is interactable");
    }

    public void ShowInteractMenu() //enables panel that reads "press e to interact"
    {
        interactPanel.SetActive(true);
    }

    public void HideInteractMenu() //disables panel that reads "press e to interact"
    {
        interactPanel.SetActive(false);
    }
}

