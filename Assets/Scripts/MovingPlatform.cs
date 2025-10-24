using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private void Start()
    {
        player = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            offset = player.transform.position - transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            player.transform.position = transform.position + offset;
        }
    }
}