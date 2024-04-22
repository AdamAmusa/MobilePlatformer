using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    InputAction movement, jump;
    Rigidbody2D rb;
    public float speed;
    public float jumpForce= 7f;
    private static float originalJumpForce;
    bool grounded;
    public float jumpBoost;
    public float jumpBoostTime = 10.0f;

    public AudioManager audioObject;

    void Start()
    {
        audioObject = FindObjectOfType<AudioManager>();
        movement = playerInput.actions.FindAction("Movement");
        jump = playerInput.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }


    //jump boost
    public void boostJump(){
        originalJumpForce = jumpForce;
        jumpForce *= jumpBoost;
        Invoke("resetJump", jumpBoostTime);
    }

    //reset jump
    public void resetJump(){
        jumpForce = originalJumpForce;
    }

    //check if boost jump is enabled
    public bool isBoostJumpEnabled(){
        return jumpForce == originalJumpForce * jumpBoost;
    }

    void Update()
    {
         movePlayer();
         Jump();
    }

    //move player
    void movePlayer(){
        Vector2 direction = movement.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;

    }

    //jump
    void Jump(){
        if(jump.triggered && grounded){
            audioObject.PlayJump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }



    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            grounded = false;
        }
    }


}
