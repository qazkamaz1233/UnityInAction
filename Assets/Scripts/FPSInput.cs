using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{

    public float speed = 0.6f;

    public float gravity = -9.8f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float forwardDeltaZ = Keyboard.current.wKey.ReadValue() * speed;
        float backDeltaZ = Keyboard.current.sKey.ReadValue() * speed;

        float rigthDeltaX = Keyboard.current.dKey.ReadValue() * speed;
        float leftDeltaX = Keyboard.current.aKey.ReadValue() * speed;

        Vector3 movement = new(rigthDeltaX - leftDeltaX, 0, forwardDeltaZ - backDeltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
    }
}
