using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 0.2f;
    public float sensitivityVer = 0.2f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float verticalRot = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        switch(axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(0, Mouse.current.delta.x.ReadValue() * sensitivityHor, 0);
                break;

            case RotationAxes.MouseY:
                verticalRot -= Mouse.current.delta.y.ReadValue() * sensitivityVer;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
                break;

            case RotationAxes.MouseXAndY:
                verticalRot -= Mouse.current.delta.y.ReadValue() * sensitivityVer;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float delta = Mouse.current.delta.x.ReadValue() * sensitivityHor;
                horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
                break;

            default: 
                break;
        }
    }
}
