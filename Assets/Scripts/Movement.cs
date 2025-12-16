using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStength;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {

        ProcessThrusting();
        ProcessRotation();

    }

    private void ProcessThrusting()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStength * Time.fixedDeltaTime);
        }

    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        transform.Translate(1f * rotationInput * Time.fixedDeltaTime, 0f, 0f);
    }

}
