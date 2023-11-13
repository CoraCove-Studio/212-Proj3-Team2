using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    [SerializeField] private bool depressed;            //is pressure plate activated or not

    [Header("ASSIGNED IN INSPECTOR")]
    //[SerializeField] private GameObject itemToDestroy;
    [SerializeField] private Collider dungeonShelf;

    [SerializeField] private Collider elementalCol;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;
    [SerializeField] private AudioClip clunkSFX, fallSFX;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        depressed = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(_tagManager.player) && !depressed && _gamePlay.placedRock) //player on top doesn't do anything other than lower plate, must place rock
    //    {                                                                               
    //        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-0.053f, this.gameObject.transform.position.z);
    //        depressed = true;
    //        //play audio click here

    //        //inserted code
    //        dungeonShelf.attachedRigidbody.useGravity = true;
    //        dungeonShelf.attachedRigidbody.isKinematic = false;

    //        //itemToDestroy.SetActive(false);
    //        elementalCol.attachedRigidbody.useGravity = true;
    //    }
    //}

    public void PressurePlateTriggered()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.053f, this.gameObject.transform.position.z);
        depressed = true;
        //play audio click here
        audioSource.volume = 0.5f;
        audioSource.clip = clunkSFX;
        audioSource.Play();

        //inserted code
        dungeonShelf.attachedRigidbody.useGravity = true;
        dungeonShelf.attachedRigidbody.isKinematic = false;

        audioSource.volume = 0.5f;
        audioSource.clip = fallSFX;
        audioSource.Play();

        //itemToDestroy.SetActive(false);
        elementalCol.attachedRigidbody.useGravity = true;
        elementalCol.attachedRigidbody.isKinematic = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(_tagManager.player) && !_gamePlay.hasRock)
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
