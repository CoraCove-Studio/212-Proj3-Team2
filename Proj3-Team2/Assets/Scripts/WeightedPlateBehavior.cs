using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPlateBehavior : MonoBehaviour
{
    [SerializeField] private bool depressed;            //is weighted plate activated or not

    [Header("ASSIGNED IN INSPECTOR")]
    //[SerializeField] private Collider dungeonShelf;
    [SerializeField] private Collider elementalCol;
    [SerializeField] private Rigidbody elementalRb;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    private void Start()
    {
        depressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {                                                               //&& _gamePlay.placedRock was causing plate to not trigger
        if (other.CompareTag(_tagManager.player) && !depressed ) //player on top doesn't do anything other than lower plate, must place rock
        {                                                                               //lowers weighted plate by 2.42. will improve code later to get rid of magic numbers
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 2.42f, this.gameObject.transform.position.z);
            depressed = true;
            print("wp triggered");
            //play audio click here

            //inserted code
            elementalRb.AddForce(0, 0, 50.0f);
            //trigger animation effect?
            //elementalCol.attachedRigidbody.useGravity = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag(_tagManager.player) && _gamePlay.placedRock)
    //    {
    //        return;
    //    }
    //    else if (other.CompareTag(_tagManager.player) && !_gamePlay.placedRock)
    //    {
    //        depressed = false;
    //        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.053f, this.gameObject.transform.position.z);
    //    }
    //}
}
