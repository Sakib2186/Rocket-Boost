using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStength;
    [SerializeField] float rotationStength;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem rocketThrust;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;
    GameObject SunLight;
    Light sun;
    AudioSource ads;
    Rigidbody rb;

    private void Awake()
    {
        SunLight = GameObject.FindGameObjectWithTag("Sun");
        sun = SunLight.GetComponent<Light>();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ads = GetComponent<AudioSource>();
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
        RotateSun();

    }

    private void ProcessThrusting()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            ads.Stop();
            rocketThrust.Stop();
        }

    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStength * Time.fixedDeltaTime);
        if (!rocketThrust.isPlaying)
        {
            rocketThrust.Play();
        }
        playAudio();
    }

    private void ProcessRotation()
    {
        if (rotation.IsPressed())
        {
            StartRotation();
        }
        else
        {
            rightThrust.Stop();
            leftThrust.Stop();
        }

    }

    private void StartRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotateLeft();

        }
        else if (rotationInput > 0)
        {
            RotateRight();

        }
        else
        {
            rightThrust.Stop();
            leftThrust.Stop();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationStength);
        if (!leftThrust.isPlaying)
        {
            rightThrust.Stop();
            leftThrust.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationStength);
        if (!rightThrust.isPlaying)
        {
            leftThrust.Stop();
            rightThrust.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //not allowing physic system to rotate. We will rotate it
        transform.Rotate(0f, 0f, 1f * rotationThisFrame * Time.fixedDeltaTime); // OR Vector3.forward
        rb.freezeRotation = false;
        
    }

    private void playAudio()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(mainEngineSFX);
        }
    }

    private void RotateSun()
    {
        sun.transform.Rotate(1f * Time.fixedDeltaTime * 15f, 0f, 0f );
    }

}
