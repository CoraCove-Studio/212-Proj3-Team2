using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorEvents : MonoBehaviour
{
    [Header("Custom Events")]
    public UnityEvent myEvents;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    //[SerializeField] private Animator objectToAnimate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.player) && _gamePlay.keysCollected == 0)
        {
            return;
        }
        else if (other.CompareTag(_tagManager.player) && _gamePlay.keysCollected >= 1)
        {
            Debug.Log("event happened");
            myEvents.Invoke();
        }
        //else if (other.CompareTag(_tagManager.player) && _gamePlay. INSERT NECESSARY COMPONENT HERE)
        //{
        //    Debug.Log("event happened");
        //    myEvents.Invoke();
        //}
    }
}

