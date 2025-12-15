using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStength;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
    }

    private void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Here1");
            moverocket();
        }
    }

    void moverocket()
    {
        rb.AddRelativeForce(Vector3.up * thrustStength * Time.fixedDeltaTime);
    }

}
