using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePhaseBehavior : MonoBehaviour
{
    [Header("Assigned In Inspector")]
    [SerializeField] private GameObject player;
    [SerializeField] public Transform pipeTravelPoint;

    //private variables
    private string water = "water";
    private string element;
    private Gameplay _gameplay;
    private TagManager _tagManager;
    private GameObject grate;

    void Start()
    {
        grate = this.gameObject;
        _gameplay = player.GetComponent<Gameplay>();
        _tagManager = player.GetComponent<TagManager>();
    }

    private void FixedUpdate()
    {
        element = _gameplay.elementalState.ToString();
    }

    /* commented out so that the gameplay script calls the trigger and not this script to insure things trigger in proper order*/

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag(_tagManager.player) && element == water)
        //{
        //    player.transform.position = pipeTravelPoint.position;
        //}
    }
}
