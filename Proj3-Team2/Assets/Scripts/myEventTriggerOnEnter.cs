using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class myEventTriggerOnEnter : MonoBehaviour
{
    [Header("Custom Events")]
    public UnityEvent myEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (myEvents == null)
        {
            Debug.Log("myEventTriggerOnEnter was triggered but myEvents was null");
        }
        else
        {
            myEvents.Invoke();
        }
    }
}
