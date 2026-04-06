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
    }

    // Update is called once per frame
    void Update()
    {
        if (downAction.IsPressed())
        {
            rigidbody.maxLinearVelocity = 20f;
        }
        else
        {
            rigidbody.maxLinearVelocity = 10f;
        }

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        float jumpValue = jumpAction.ReadValue<float>();

        Vector3 moveForce = new Vector3(moveValue.x, jumpValue, moveValue.y);

        rigidbody.AddForce(transform.TransformDirection(moveForce));

        /*Vector2 lookValue = cameraAction.ReadValue<Vector2>();

        rigidbody.rotation *= Quaternion.AngleAxis(lookValue.x, Vector3.up);
        Quaternion yRotation = Quaternion.AngleAxis(lookValue.y, Vector3.left);
        Vector3 yRotationEuler = yRotation.eulerAngles;
        yRotationEuler.x = Mathf.Clamp(yRotationEuler.x, -90f, 90f);
        yRotationEuler.z = Mathf.Clamp(yRotationEuler.z, -90f, 90f);
        camera.transform.rotation *= yRotationEuler;*/
    }
}
