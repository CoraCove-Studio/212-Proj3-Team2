using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private Transform player;
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private float playerSpeed;
    //jump
    [SerializeField] private KeyCode jump; //space
    [SerializeField] private float jumpDuration;
    [SerializeField] private float jumpCoolDown;

    [Header("ASSIGNED IN GAMEPLAY")]
    [SerializeField] private bool isJumping;
    [SerializeField] private bool canJump;
    [SerializeField] private Vector3 moveDirection;

    [Header("INPUT VALUES")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float jumpPower;
    
    [Header("OTHER SCRIPTS")]
    [SerializeField] private Gameplay _gameplay;
    [SerializeField] private PlayerAnimation _anim;

    private string levelThree;
    private string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        sceneName = sceneName = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();

        if (_gameplay.elementalState == "air")
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void Update()
    {
        if (sceneName == levelThree)
        {
            if (isJumping && _gameplay.elementalState == "air")
            {
                jumpDuration -= Time.deltaTime;
                if (jumpDuration <= 0)
                {
                    isJumping = false;
                    canJump = false;
                    jumpDuration = 3.0f;
                }
            }
            else if (!canJump && _gameplay.elementalState == "air")
            {
                jumpCoolDown -= Time.deltaTime;
                if (jumpCoolDown <= 0)
                {
                    canJump = true;
                    jumpCoolDown = 1.0f;
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        GetPlayerInput();
        MovePlayer();
        MoveAnimation();
        //Rotate();

        if (canJump && Input.GetKey(jump) && _gameplay.elementalState == "air")
        {
            Jump();
        }
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput <= -1) //moving right
        {
            moveDirection = new Vector3(-1, 0, 0);
        }
        else if(horizontalInput >= 1) //moving left
        {
            moveDirection = new Vector3(1, 0, 0);
        }
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

    //private void Rotate()
    //{
    //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 0.5f);
    //}
    private void Jump()
    {
        isJumping = true;
        rb.velocity = new Vector3(0, jumpPower, 0);
    }

    private void MoveAnimation()
    {
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            _anim.Walk(true);
        }
        else
        {
            _anim.Walk(false);
        }
    }
}
