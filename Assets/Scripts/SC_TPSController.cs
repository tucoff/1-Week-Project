using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_TPSController : MonoBehaviour
{
    public string side = "";
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    public Animator animator;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * vertical : 0;
            float curSpeedY = canMove ? speed * horizontal : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if(moveDirection == Vector3.zero)
            {
                animator.SetFloat("Speed", 0);
                animator.Play("Idle");
            }
            else
            {
                animator.SetFloat("Speed", 1);
                animator.Play("Walking");

            }

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
                animator.Play("Jump");
            }
        }

        float h = 0;
        float v = 0;
        if (horizontal < 0) { h = horizontal*-1; } else { h = horizontal; }
        if (vertical < 0) { v = vertical*-1; } else { v = vertical; }

        if(v>=h)
        {
            if (vertical > 0){GameObject.Find("Character").transform.localRotation = Quaternion.Euler(0,0,0);}
            else {GameObject.Find("Character").transform.localRotation = Quaternion.Euler(0,180,0);} 
        }
        else if (v<h)
        {
            if (horizontal >= 0){GameObject.Find("Character").transform.localRotation = Quaternion.Euler(0,90,0);}
            else{GameObject.Find("Character").transform.localRotation = Quaternion.Euler(0,270,0);}
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}