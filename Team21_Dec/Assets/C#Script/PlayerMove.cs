using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] Transform fireObject;

    public float PlayerHealth = 100f;
    public bool isRunning;
    public float Distance;
    public float ChangeHealth = 10f;
    public AudioSource footstepSound;
    Vector2 moveInput;
    Rigidbody myRigidbody;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Distance = Vector3.Distance(this.transform.position, fireObject.transform.position);
        HealthCalculator();
    }

    private void RunPressed()
    {
        isRunning = true;
    }

    private void RunReleased()
    {
        isRunning = false;
    }

    void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, myRigidbody.velocity.y, moveInput.y * walkSpeed);
        myRigidbody.velocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        footstepSound.Play();
    }

    void HealthCalculator()
    {
        if (PlayerHealth <= 100)
        {
            if (Distance > 7f)
            {
                PlayerHealth -= ChangeHealth * Time.deltaTime;
            }
            else if (Distance <= 7f)
            {
                PlayerHealth += 3 * ChangeHealth * Time.deltaTime;
            }
        }

        if (PlayerHealth >= 100)
            PlayerHealth = 100;
    }
}
