using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private float playerSpeed;

    [Header("INPUT VALUES")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetPlayerInput();
        MovePlayer();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector3(horizontalInput * playerSpeed, 0, verticalInput * playerSpeed);
    }
}
