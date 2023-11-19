using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockEvents : MonoBehaviour
{
    [Header("Custom Events")]
    public UnityEvent myEvents;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    //[SerializeField] private Animator objectToAnimate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.player) && !_gamePlay.hasRock)
        {
            return;
        }
        else if (other.CompareTag(_tagManager.player) && !_gamePlay.placedRock)
        {
            Debug.Log("event happened");
            myEvents.Invoke();
        }
        else if (other.CompareTag(_tagManager.player) && _gamePlay.placedRock)
        {
            Debug.Log("event happened");
            myEvents.Invoke();
        }
    }
}
