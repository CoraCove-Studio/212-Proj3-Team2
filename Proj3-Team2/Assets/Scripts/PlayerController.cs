using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private Transform player;
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private float playerSpeed;

    [Header("INPUT VALUES")]
    [SerializeField] private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        GetPlayerInput();
        MovePlayer();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector3(horizontalInput * playerSpeed, 0, 0);

        if (player.position.y > 0)
        {
            rb.velocity = new Vector3(horizontalInput * playerSpeed, -2, 0);
        }
        else
        {
            rb.velocity = new Vector3(horizontalInput * playerSpeed, 0, 0);
        }
    }
}
