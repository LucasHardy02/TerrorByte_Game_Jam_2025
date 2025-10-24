using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{

    static bool isGrounded = true;
    public Vector3 movement;
    public Transform cameraTransform;

    private bool flingState = false;
    private bool isFlingable = true;
    public float flingForceForward = 9000;
    public float flingForceUp = 2000;
    public GameObject failFling;
    public GameObject Player;
    private Rigidbody rb;

    public float coyTimeDur = 0.2f;
    private float coyTimeCount;
    private bool hasJumped = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //Fling

        if (isFlingable == true && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            flingState = true;
            rb.AddForce(Player.transform.forward * flingForceForward);
            rb.AddForce(Vector3.up * flingForceUp);

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
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += forward; ;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement -= right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += right;
        }

        rb.transform.position += movement * 5 * Time.deltaTime;

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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isFlingable = true;
            hasJumped = false;
        }
        if (collision.gameObject.CompareTag("Bedrock"))
        {
            isGrounded = true;
            isFlingable = false;
            hasJumped = false;
        }

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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}