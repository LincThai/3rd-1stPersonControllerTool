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
    public float gravity = 9.8f;

    // angle smoothing
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        // get input values
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical"); // also known as y in 2d graph

        // set a nomalized vector for movement based on input
        Vector3 direction = new Vector3(x, 0, z).normalized;

        // check their has been input
        if (direction.magnitude >= 0.1f)
        {
            // find the target angle based on movement then smooth and apply
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // apply movement
            controller.Move(direction * walkSpeed * Time.deltaTime);
        }


    }
}
