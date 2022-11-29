using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 1f;
    public float gravity = -9.81f;

    public float jumpHeight = 2f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GetComponent<PlayerInfo>().sitting)
        {
            controller.detectCollisions = true;
            handleMovement();
        }
        else
        {
            controller.detectCollisions = false;
        }
    }
    
    void handleMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask.value);

        GetComponent<PlayerInfo>().grounded = isGrounded;

        //if (isGrounded)
        //{
        //    speed = 15f;
        //} 
        //else
        //{
        //    speed = 15f;
        //}

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move((transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(new Vector3(0, velocity.y * Time.deltaTime));
    }
}
