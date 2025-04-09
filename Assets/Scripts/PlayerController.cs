using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // set variable
    // references
    public CharacterController controller;

    // basic player variables
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public float jumpHeight = 2;
    public float gravity = -9.8f;
    public float acceleration = 0.5f;

    // make float for moveSpeed
    float moveSpeed;

    // angle smoothing
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // jump/grounding variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;

    private void Start()
    {
        // set a speed of movement to the walking speed
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // walk and run
        // get input values
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); // also known as y in 2d graph

        // set a nomalized vector for movement based on input
        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // when holding the sprint key
            // lerp between the current speed of movement to the running speed by increasing gradually by the acceleration over time
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // when sprint key is released
            // lerp between the current speed of movement to the walking speed by increasing gradually by the acceleration over time
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }

        Debug.Log(moveSpeed);

        // check their has been input
        if (direction.magnitude >= 0.1f)
        {
            // find the target angle based on movement then smooth and apply
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // apply movement
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        // jump
        // check if the players is grounded by forming a sphere at groundCheck with the radius of groundDistance
        // then see if this sphere has collided with an object with a layer mask equal to groundMask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // ensures the player is firmly on the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
