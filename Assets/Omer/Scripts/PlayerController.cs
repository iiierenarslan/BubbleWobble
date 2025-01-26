using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private float gravityScale = 1f;

    private float horizontalInput;
    private float verticalInput;
    private float rotationSpeed = 5f;

    private Vector3 moveDirection;
    public Vector3 playerScale;


    private bool isGrounded;
    private bool isMoving;  
    private float gravity = -9.81f;

    private AudioSource audioSource;

    public static PlayerController instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.useGravity = false;
        playerScale = transform.localScale;
        
    }

    void FixedUpdate()
    {
        HandleMovement();
        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;


        Vector3 inputDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

        inputDirection.Normalize();

        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = inputDirection * speed;
            isMoving = true;
        }
        else if (GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            moveDirection = Vector3.zero;
            isMoving = false;
        }


        else
        {
            moveDirection = Vector3.zero;
            isMoving = false;
        }

        if (!isGrounded)
        {
            moveDirection.y += gravity * gravityScale;
        }
        else
        {
            moveDirection.y = rb.velocity.y;
        }


        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);


        if (new Vector3(inputDirection.x, 0, inputDirection.z).magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(inputDirection.x, 0, inputDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
}
