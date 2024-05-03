using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public AudioSource audioSource;
    public AudioClip song;
    public float volume;

    private bool canMove = true;
    private bool cankey = false;
    private bool tutorial = true;

    public GameObject Tutorialtxt;
    public GameObject Tutorialtxt2;
    public GameObject Tutorialtxt3;
    public GameObject Tutorialtxt3_1;
    public GameObject Tutorialtxt4;
    public GameObject Amelia1;
    public GameObject Amelia2;
    public GameObject Amelia3;
    public GameObject Amelia4;
    public GameObject Panel;
    public float cannon_ball = 0;
    public float canR = 0;
    public float final_message = 0;

    void Start()
    {
        audioSource.PlayOneShot(song, volume);

        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && cankey == false)
        {
            cankey = true;
            Tutorialtxt.SetActive(false);
            Amelia1.SetActive(false);

            Tutorialtxt2.SetActive(true);
            Amelia2.SetActive(true);
        }

        if(tutorial == true)
        {
            if (Input.GetButtonDown("Fire1") && cankey == true && canR == 0)
            {
                Tutorialtxt2.SetActive(false);
                Amelia2.SetActive(false);

                Tutorialtxt3.SetActive(true);
                Tutorialtxt3_1.SetActive(true);
                Amelia3.SetActive(true);
                canR = 1;
            }

            if(Input.GetKey(KeyCode.R) && canR == 1)
            {
                cannon_ball = 1;
                
            }
            
            if (Input.GetButtonDown("Fire1") && cannon_ball == 1)
            {
                Tutorialtxt3.SetActive(false);
                Tutorialtxt3_1.SetActive(false);
                Amelia3.SetActive(false);

                Tutorialtxt4.SetActive(true);
                Amelia4.SetActive(true);
                final_message = 1;

            }

            if(Input.GetKey(KeyCode.R) && final_message == 1)
            {
                Tutorialtxt4.SetActive(false);
                Amelia4.SetActive(false);
                Panel.SetActive(false);
                tutorial = false;

            }
        }



        if (cankey == true)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);


            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftControl) && canMove)
            {
                characterController.height = crouchHeight;
                walkSpeed = crouchSpeed;
                runSpeed = crouchSpeed;

            }
            else
            {
                characterController.height = defaultHeight;
                walkSpeed = 6f;
                runSpeed = 12f;
            }

            characterController.Move(moveDirection * Time.deltaTime);

        }

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}