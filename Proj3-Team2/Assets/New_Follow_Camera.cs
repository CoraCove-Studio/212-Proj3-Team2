using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset the camera from the player

    void Update()
    {
        if (player != null)
        {
            // Set the position of the camera to the player's position plus the offset
            transform.position = player.position + offset;
        }
        else
        {
            Debug.LogWarning("Player reference is missing. Assign the player object to the script.");
        }
    }
}