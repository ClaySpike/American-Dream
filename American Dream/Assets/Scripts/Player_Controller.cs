using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float moveSpeed;
    public float runSpeed;
    public float diagnalMoveModifier;
    private float currentMoveSpeed;

    private bool playerMoving;
    public Vector2 lastMove;

    private Animator anim;
    public float walkAnimationSpeed;
    public float runAnimationSpeed;
    private Rigidbody2D playerRigidBody;

    private static bool playerExists;

    public bool canMove;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Updated at a fixed framerate
    private void FixedUpdate()
    {

        if (Input.GetAxisRaw("b") > 0.5f)
        {
            anim.speed = runAnimationSpeed;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > .5f)
            {
                currentMoveSpeed = runSpeed * diagnalMoveModifier;
            }
            else
            {
                currentMoveSpeed = runSpeed;
            }
        }
        else
        {
            anim.speed = walkAnimationSpeed;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > .5f)
            {
                currentMoveSpeed = moveSpeed * diagnalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
        }
        playerMoving = false;

        if (!canMove)
        {
            playerRigidBody.velocity = Vector2.zero;
            anim.SetBool("PlayerMoving", false);
            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", 0f);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
            return;
        }

        if (Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f)
        {
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, playerRigidBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0f, playerRigidBody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > .5f || Input.GetAxisRaw("Vertical") < -.5f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0f);
        }

        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
