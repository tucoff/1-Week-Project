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
        animator.SetFloat("MoveSpeed",1f);
        speed = 7.5f;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        if (Input.GetKey(KeyCode.LeftShift) && !transform.GetComponent<SC_Hold>().isHolding())
        {
            animator.SetFloat("MoveSpeed",2f);
            speed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetFloat("MoveSpeed",1f);
            speed = 7.5f;
        }

        if (characterController.isGrounded)
        {
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

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

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