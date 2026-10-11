using UnityEngine;
using UnityEngine.InputSystem;

public class FPSInput : MonoBehaviour
{

    public float speed = 0.6f;

    void Start()
    {
        
    }

    void Update()
    {
        float forwardDeltaZ = Keyboard.current.wKey.ReadValue() * speed;
        float backDeltaZ = Keyboard.current.sKey.ReadValue() * speed;

        float rigthDeltaX = Keyboard.current.dKey.ReadValue() * speed;
        float leftDeltaX = Keyboard.current.aKey.ReadValue() * speed;

        transform.Translate((rigthDeltaX - leftDeltaX) * Time.deltaTime, 0, (forwardDeltaZ - backDeltaZ) * Time.deltaTime);
    }
}
