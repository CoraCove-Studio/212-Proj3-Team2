using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningDoorBehavior : MonoBehaviour
{
    [SerializeField] public bool burned;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    private void Start()
    {
        burned = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.player) && !burned && _gamePlay.elementalState == "fire") //player on top doesn't do anything other than lower plate, must place rock
        {
            //smoke particle effect
            burned = true;
        }
    }
}
