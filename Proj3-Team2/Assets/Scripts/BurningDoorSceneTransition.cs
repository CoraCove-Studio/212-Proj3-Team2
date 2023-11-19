using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurningDoorSceneTransition : MonoBehaviour
{
    [Header("Custom Events")]
    public UnityEvent myEvents;

    [Header("SCRIPTS - ASSIGNED IN INSPECTOR")]
    [SerializeField] private Gameplay _gamePlay;
    [SerializeField] private TagManager _tagManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagManager.player) && _gamePlay.elementalState != "fire")
        {
            return;
        }
        else if (other.CompareTag(_tagManager.player) && _gamePlay.elementalState == "fire")
        {
            Debug.Log("event happened");
            myEvents.Invoke();
        }
    }
}
