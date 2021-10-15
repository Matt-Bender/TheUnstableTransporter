using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed;
    public GameObject player;
    public float dash;
    public float jump;
    private bool dashCooldown = false;
    private bool jumpCooldown = false;
    public float cooldownTimer;
    public Vector3 playerSize;
    private bool playerUp = false;
    private bool playerMed = true;
    private bool playerDown = false;
    //how much the cube transforms by
    //the higher the number the higher the difference
    public float playerStateFactor;

    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;



    //uncomment if a delay between transformations is wanted
    //public float cooldownState;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player.transform.localScale = new Vector3(playerSize.x, playerSize.y, playerSize.z);
        if (!groundCheck)
        {
            Debug.Log("Groundcheck is not found. Please assign an object to be the groundcheck");
        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
    }

    void ResetDashCooldown()
    {
        dashCooldown = false;
    }
    void ResetJumpCooldown()
    {
        jumpCooldown = false;
    }
    //tall and skinny
    void playerStateUp()
    {
        playerUp = true;
        playerMed = false;
        playerDown = false;
    }
    //cube
    void playerStateMed()
    {
        playerUp = false;
        playerMed = true;
        playerDown = false;
    }
    //flat
    void playerStateDown()
    {
        playerUp = false;
        playerMed = false;
        playerDown = true;
    }
    void playerState()
    {
        Vector3 playerPos = transform.position;
        if (playerUp)
        {
            //high
            //Debug.Log("High");
            player.transform.localScale = new Vector3(playerSize.x / playerStateFactor, playerSize.y * playerStateFactor, playerSize.z);
            playerPos.y = -1.785f;
            transform.position = playerPos;
        }
        else if (playerMed)
        {
            //default
            //Debug.Log("Med");
            player.transform.localScale = new Vector3(playerSize.x, playerSize.y, playerSize.z);
            playerPos.y = -3.285f;
            transform.position = playerPos;
        }
        else if (playerDown)
        {
            //bottom
            //Debug.Log("Low");
            player.transform.localScale = new Vector3(playerSize.x * playerStateFactor, playerSize.y / playerStateFactor, playerSize.z);
            playerPos.y = -3.66f;
            transform.position = playerPos;
        }
    }
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        //int transform 3 states small medium large
        //0, 1, 2
        //input transform up
        if (player != null)
        {
            //input transforms up
            if (Input.GetKeyDown("w"))
            {
                //if already medium become tall
                if (playerMed)
                {
                    playerStateUp();
                }
                //if already short become medium
                else if (playerDown)
                {
                    playerStateMed();
                }
                //uncomment if a delay between transformations is wanted
                //Invoke("playerState", cooldownState);
                playerState();
            }
            //input transforms down
            if (Input.GetKeyDown("s"))
            {
                //if already medium become short
                if (playerMed)
                {
                    playerStateDown();
                }
                //if already tall become medium
                else if (playerUp)
                {
                    playerStateMed();
                }
                //uncomment if a delay between transformations is wanted
                //Invoke("playerState", cooldownState);
                playerState();
            }
            float playerScore = player.transform.position.x;
            //increase speed over time
                speed = (playerScore / 100) + 10;
                //reduce cooldown timer as you progress
                if (playerScore > 500)
                {
                    cooldownTimer = 0.1f;
                }
                else if (playerScore > 200)
                {
                    cooldownTimer = 0.2f;
                }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
            if (Input.GetButtonDown("Jump"))
            {
                //can jump if either on the platform or cooldown is off
                if (isGrounded || jumpCooldown == false)
                {
                    myRigidBody.transform.Translate(0, jump, 0);
                    jumpCooldown = true;
                    Invoke("ResetJumpCooldown", cooldownTimer);
                }
            }
            if (Input.GetKeyDown("d"))
            {
                if (dashCooldown == false)
                {
                    myRigidBody.transform.Translate(dash, 0, 0);
                    dashCooldown = true;
                    Invoke("ResetDashCooldown", cooldownTimer);
                }
            }

        }
    }
}
