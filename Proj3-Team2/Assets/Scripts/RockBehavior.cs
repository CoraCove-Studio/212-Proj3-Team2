using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    [SerializeField] public bool attachedToPlayer;
    [SerializeField] public bool depositedOnPlate;
    [SerializeField] private GameObject player;
    [SerializeField] private float playerXPos;
    [SerializeField] private float playerYPos;
    [SerializeField] private float playerZPos;
    [SerializeField] private GameObject pressurePlate;

    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (attachedToPlayer)
        {
            playerXPos= player.transform.position.x;
            playerYPos = player.transform.position.y;
            playerZPos= player.transform.position.z;
            gameObject.transform.position= new Vector3(playerXPos - 0.51f, playerYPos + 0.41f, playerZPos);
        }
        else if(depositedOnPlate)
        {
            gameObject.transform.position = pressurePlate.transform.position;
        }
    }
}
