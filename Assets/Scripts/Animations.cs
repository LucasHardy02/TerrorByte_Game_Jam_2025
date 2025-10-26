using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator playerAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnim = playerAnim.GetComponent<Animator>();

        playerAnim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnim.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.Play("Fling");
        }
        else if (Input.GetKey(KeyCode.Space))
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