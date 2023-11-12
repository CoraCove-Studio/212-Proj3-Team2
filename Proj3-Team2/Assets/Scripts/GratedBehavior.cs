using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratedBehavior : MonoBehaviour
{
    [Header("Assigned In Inspector")]
    [SerializeField] private GameObject player;
    
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tagManager.player) && element == water)
        {
            grate.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
