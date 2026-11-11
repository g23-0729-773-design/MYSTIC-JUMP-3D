using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;
    public float rotationSpeed = 10f;

    [Header("Jump Settings")]
    public float jumpHeight = 2.5f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // CHECK GROUND
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // WASD MOVEMENT
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z);
        move = Vector3.ClampMagnitude(move, 1f);

        // ROTATE PLAYER
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation =
            Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
            );
        }

        // SPACEBAR JUMP
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(
            jumpHeight * -2f * gravity
            );

            Debug.Log("JUMP SUCCESS!");
        }

        // APPLY GRAVITY
        velocity.y += gravity * Time.deltaTime;

        // COMBINE MOVEMENT
        Vector3 finalMovement =
        move * speed + Vector3.up * velocity.y;

        controller.Move(finalMovement * Time.deltaTime);
    }
}


