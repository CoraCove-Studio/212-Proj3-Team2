using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    [SerializeField] public bool attachedToPlayer;
    [SerializeField] public bool depositedOnPlate;
    [SerializeField] private GameObject playerRockLocation;
    [SerializeField] private GameObject pressurePlate;

    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (attachedToPlayer)
        {
            gameObject.transform.position= playerRockLocation.transform.position;
        }
        else if(depositedOnPlate)
        {
            gameObject.transform.position = pressurePlate.transform.position;
        }
    }
}
