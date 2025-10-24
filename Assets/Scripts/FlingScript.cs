using UnityEngine;

public class FlingScript : MonoBehaviour
{
    private bool flingState = false;
    private bool isGrounded;
    private bool isFlingable;
    private float flingForceForward = 700;
    private float flingForceUp = 200;
    public GameObject failFling;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        failFling.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {


        if (isFlingable == true && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.forward * flingForceForward);
            rb.AddForce(Vector3.up * flingForceUp);

        }
        else if (isFlingable == false && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            failFling.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isFlingable = true;
        }
        if (collision.gameObject.CompareTag("Bedrock"))
        {
            isGrounded = true;
            isFlingable = false;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}