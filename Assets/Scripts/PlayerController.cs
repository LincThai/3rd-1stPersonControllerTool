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

    // Update is called once per frame
    void Update()
    {
        // get input values
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    }
}
