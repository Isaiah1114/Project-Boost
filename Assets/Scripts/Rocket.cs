using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    GameObject levelManager = new GameObject();
    Rigidbody rigidBody;
    AudioSource audio;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip win;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem winParticles;

    enum State { Alive, Dying, Trancending}
    State state = State.Alive;
    bool collisionsDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToRotateInput();
            RespondToThrustInput();

        }
        if (Debug.isDebugBuild)
        {
            RespondToDebugInput();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || collisionsDisabled)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("okay");

                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audio.Stop();
        audio.PlayOneShot(death);
        deathParticles.Play();
        
    }

    private void StartFinishSequence()
    {
        state = State.Trancending;
        audio.Stop();
        audio.PlayOneShot(win);
        winParticles.Play();
        
    }



    private void RespondToRotateInput()
    {

        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.freezeRotation = true; // take manual control of rotation
            transform.Rotate(Vector3.forward * rotationThisFrame); //z axis
            rigidBody.freezeRotation = false; // resume physics control of rotation
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.freezeRotation = true; // take manual control of rotation
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            rigidBody.freezeRotation = false; // resume physics control of rotation
        }

    }

    void RespondToThrustInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        else
        {
            audio.Stop();
            mainEngineParticles.Stop();
        }
    }

    void RespondToDebugInput()
    {

        if (Input.GetKey(KeyCode.L))
        {

            
            levelManager.LoadnextLevel();
        }

        if (Input.GetKey(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }
    }

    private void Thrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); // y axis
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();
    }

}
