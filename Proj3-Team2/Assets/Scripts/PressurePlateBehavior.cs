using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.UI;
using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    [SerializeField] private bool depressed;            //is pressure plate activated or not

    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private GameObject itemToDestroy;
    [SerializeField] private Collider elementalCol;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    private void Start()
    {
        depressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.player) && !depressed && _gamePlay.placedRock) //player on top doesn't do anything other than lower plate, must place rock
        {                                                                               
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-0.053f, this.gameObject.transform.position.z);
            depressed = true;
            //play audio click here
            itemToDestroy.SetActive(false);
            elementalCol.attachedRigidbody.useGravity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(_tagManager.player) && _gamePlay.placedRock)
        {
            return;
        }
        else if(other.CompareTag(_tagManager.player) && !_gamePlay.placedRock)
        {
            depressed = false;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.053f, this.gameObject.transform.position.z);
        }
    }
}
