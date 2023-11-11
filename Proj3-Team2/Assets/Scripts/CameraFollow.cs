using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("ASSIGNED VIA INSPECTOR")]
    [SerializeField] private Transform player;

    [Header("ADJUSTED VIA INSPECTOR")]
    [SerializeField] private float camFollowSpeed;
    [SerializeField] private float xFollowDistance;
    [SerializeField] private float zFollowDistance;
    [SerializeField] private float moveThreshold;

    // Update is called once per frame
    void Update()
    {
        float xDistance = transform.position.x - player.position.x;
        float zDistance = transform.position.z - player.position.z;

        Vector3 newPosition = transform.position;

        float xMoveThreshold = Mathf.Abs(xDistance - xFollowDistance);
        float zMoveThreshold = Mathf.Abs(zDistance - zFollowDistance);

        if (xMoveThreshold > moveThreshold)
        {
            if (xDistance > xFollowDistance)
            {
                newPosition.x -= transform.right.x;
            }

            else if (xDistance < xFollowDistance)
            {
                newPosition.x += transform.right.x;
            }
        }

        if (zMoveThreshold > moveThreshold)
        {
            if (zDistance > zFollowDistance)
            {
                newPosition.z -= transform.forward.z;
            }

            else
            {
                newPosition.z += transform.forward.z;
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, camFollowSpeed * Time.deltaTime);
    }
}