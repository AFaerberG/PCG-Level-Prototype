using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    InputAction cameraAction;
    InputAction jumpAction;
    InputAction downAction;

    [SerializeField] GameObject camera;

    Rigidbody rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        cameraAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");
        downAction = InputSystem.actions.FindAction("Sprint");

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxLinearVelocity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        rigidbody.AddForce(new Vector3(moveValue.x, 0, moveValue.y));

        rigidbody.linearVelocity = new Vector3(moveValue.x * 10, rigidbody.linearVelocity.y, moveValue.y * 10);

        Vector2 lookValue = cameraAction.ReadValue<Vector2>();

        rigidbody.rotation *= Quaternion.AngleAxis(lookValue.x, Vector3.up);
        camera.transform.rotation *= Quaternion.AngleAxis(lookValue.y, Vector3.left);

        if (downAction.IsPressed())
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, -10, rigidbody.linearVelocity.z);
        }

        if (jumpAction.IsPressed())
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, 10, rigidbody.linearVelocity.z);
        }
    }
}
