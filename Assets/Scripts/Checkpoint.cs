using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Transform respawn1;
    [SerializeField] public Transform respawn2;
    [SerializeField] public Transform respawn3;
    private int checkpointCount = 1;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody RB = player.GetComponent<Rigidbody>();

        if (other.CompareTag("Checkpoint"))
        {
            other.GameObject().SetActive(false);
            checkpointCount += 1;
        }

        if (other.CompareTag("Water"))
        {
            if (checkpointCount == 2)
            {
                player.transform.position = respawn2.transform.position;
            }
            else if (checkpointCount == 3)
            {
                player.transform.position = respawn3.transform.position;
            }
            else
            {
                player.transform.position = respawn1.transform.position;
            }
        }
    }
}
