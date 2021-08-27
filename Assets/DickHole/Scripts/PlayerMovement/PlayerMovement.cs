using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    private PhotonView view;

    private PlayerAnimatorController playerAnimatorController;

    public float runSpeed = 350f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimatorController = GetComponentInChildren<PlayerAnimatorController>();
        /* view = GetComponent<PhotonView>(); */
    }

    // Update is called once per frame
    void Update()
    {
/*         if(view.IsMine){ */
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            jump();
            Attack();
/*         } */
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed * Time.deltaTime, rb.velocity.y);
        if(rb.velocity.x != 0 && itsgrounded){
            playerAnimatorController.PlayerInMove(true);
        }else{
            playerAnimatorController.PlayerInMove(false);
        }  
        RotatePlayer();     
    }

    private void RotatePlayer(){
        if(rb.velocity.x < 0){
            transform.eulerAngles = new Vector3(0,0,0);
        }else if(rb.velocity.x > 0){
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }


    public float jumpForce, jumpTime, airtime;
    float jumpTimeCounter, airtimecounter;
    public bool itsgrounded, stoppedJumping;
    RaycastHit groundhit;

    public void Itsgrounded(bool _grounded){
        itsgrounded = _grounded;
        playerAnimatorController.Falling(_grounded);
    }

    private void Attack(){
        if (Input.GetKeyDown(KeyCode.F)){
            playerAnimatorController.Attack();
        }
    }
    void jump()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1.3f, Color.blue,3);
        Debug.DrawRay(transform.position, rb.velocity*0.5f, Color.red);
        //grounded its treated on child floor colider element

        //due roof colition or end of acceleration, hold jump its not required anymore.
        if (rb.velocity.y == 0)
        {stoppedJumping = true;}

        //keydown
        if (Input.GetKeyDown(KeyCode.W) && itsgrounded == true)
        {
            airtimecounter = airtime;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            itsgrounded = false;
            stoppedJumping = false;
            playerAnimatorController.Jump();
        }
        if (Input.GetKey(KeyCode.W) && stoppedJumping == false)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                if (airtimecounter > 0)
                {
                    //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * ((airtimecounter / airtime)*1.3f));
                    airtimecounter -= Time.deltaTime;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            airtimecounter = airtime;
            jumpTimeCounter = jumpTime;
            stoppedJumping = true;
        }
        if (Input.GetKey(KeyCode.W) == false)
        {
            airtimecounter = airtime;
            jumpTimeCounter = jumpTime;
            stoppedJumping = true;
        }
    }

}
