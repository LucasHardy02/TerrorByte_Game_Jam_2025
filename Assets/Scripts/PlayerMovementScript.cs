using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{

    static bool isGrounded = true;
    public Vector3 movement;
    public Transform cameraTransform;
    public Health healthScript;

    private bool flingState = false;
    private bool isFlingable = true;
    public float flingForceForward = 3000;
    public float flingForceUp = 2000;
    public GameObject failFling;
    public GameObject Player;
    private Rigidbody rb;
    private bool isCharging;
    private float chargeTime;

    public float coyTimeDur = 0.2f;
    private float coyTimeCount;
    private bool hasJumped = false;
    public int movementSpeed;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (healthScript == null)
        {
            healthScript = FindObjectOfType<Health>();
        }

    }


    void Update()
    {
        //Fling
        if (isGrounded == false)
        {
          
            movement = Vector3.one;
        }

        if (isFlingable == true && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            chargeTime = Time.time;
            isCharging = true;
            rb.linearVelocity = Vector3.zero;
            rb.mass = 100000000;

        }
        if (isFlingable == true && isGrounded == true && Input.GetKeyUp(KeyCode.LeftShift) && isCharging)
        {
            rb.mass = 6;
            flingState = true;
            float chargeDuration = Time.time - chargeTime;
            if (chargeDuration > 3)
            {
                chargeDuration = 3;
            }
            float chargeforceForward = flingForceForward * chargeDuration;

            if (chargeforceForward > 9000)
            {
                chargeforceForward = 9000;
            }

            
                rb.AddForce(Player.transform.forward * chargeforceForward);
                rb.AddForce(Vector3.up * flingForceUp);
                isCharging = false;
            

        }
        else if (isFlingable == false && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            failFling.SetActive(true);
        }

        if (isGrounded)
        {
            coyTimeCount = coyTimeDur;
        }
        else
        {
            coyTimeCount -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((isGrounded == true && coyTimeCount > 0) && hasJumped == false)
            {
                hasJumped = true;
                GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
                coyTimeCount = 0;

            }
        }
        

       
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // keep only horizontal direction
        cameraForward.Normalize();

        if (movement != Vector3.zero)
        {
            rb.transform.forward = movement.normalized;
            rb.transform.forward = cameraForward;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) < 45f) 
            {
                if (collision.gameObject.CompareTag("Ground"))
                {
                    isGrounded = true;
                    isFlingable = true;
                    hasJumped = false;
                }
                else if (collision.gameObject.CompareTag("Bedrock"))
                {
                    isGrounded = true;
                    isFlingable = false;
                    hasJumped = false;
                }

                return;
            }
        }

        // If no upward-facing contact points are found, treat as in-air
        isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        else if (collision.gameObject.CompareTag("Bedrock"))
        {
            isGrounded = false;
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        rb.linearVelocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //    }
        

        

       


    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            healthScript.TakeDamage(1);
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            healthScript.Heal(1);
        }
    }

    
    private void FixedUpdate()
    {


        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += forward * movementSpeed;

        }

        if (Input.GetKey(KeyCode.A))
        {
            movement -= right * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= forward * movementSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += right * movementSpeed;
        }

        
            rb.AddForce(movement);



        

    }
}