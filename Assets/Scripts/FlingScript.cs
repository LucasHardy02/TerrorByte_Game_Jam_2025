using UnityEngine;

public class FlingScript : MonoBehaviour
{
    private bool flingState = false;
    private bool isGrounded;
    private bool isFlingable;
    public float flingForceForward = 9000;
    public float flingForceUp = 2000;
    public GameObject failFling;
    public GameObject Player;
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
            flingState = true;
            rb.AddForce(Player.transform.forward * flingForceForward);
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