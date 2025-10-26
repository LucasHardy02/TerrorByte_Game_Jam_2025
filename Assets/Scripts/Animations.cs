using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = GetComponent<Animator>();

        playerAnim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.Play("Walk");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnim.Play("Fling");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.Play("Jump");
        }
        else
        {
            playerAnim.Play("Idle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAnim.Play("Attack");
        }
    }
}