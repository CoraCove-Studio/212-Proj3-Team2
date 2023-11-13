using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerEnter : MonoBehaviour
{
    [Header("AssignedInInspector")]
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Animator>().enabled = true;
    }
}
