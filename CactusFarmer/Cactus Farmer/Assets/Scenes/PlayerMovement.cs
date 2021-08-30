using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    public CharacterController controller;

    [SerializeField] public Transform playerCamera;
    [SerializeField] public float mouseSensitivity;

    //gravity value
    [SerializeField] float gravity = -13f;
    //velocity when falling
    float velocityY = 0f;

    
    private bool isJumping;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;

    //bool to lock cursor and make it invisible
    bool lockCursor = true;

    float cameraPitch = 0f;

    //movement smooth
    [SerializeField] [Range(0f, 0.5f)] float moveSmoothTime = 0.1f;    
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    //mouselook smoothing
    [SerializeField] [Range(0f, 0.5f)] float mouseMoveSmoothTime = 0.03f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseVelocity = Vector2.zero;
    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateMouseLook();
        UpdateMovement();

    }


    void UpdateMouseLook()
    {
        
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseVelocity, mouseMoveSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        //clamp camera so it cant go past bottom or top
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x ) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        JumpInput();

    }



    void JumpInput()

    {

        if (Input.GetKeyDown("space") && !isJumping)
        {
            isJumping = true;

            StartCoroutine(JumpEvent());

        }

    }



    IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90f;

        float timeInAir = 0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);

            controller.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);

            timeInAir += Time.deltaTime;

            yield return null;

        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45f;

        isJumping = false;

    }

}

