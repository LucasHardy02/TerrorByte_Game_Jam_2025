using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float rotationSpeed = 5f;
    public float smoothSpeed = 5f;

    private Vector3 offset;
    private Vector3 desiredOffset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        desiredOffset = offset;

    }

    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            desiredOffset = Quaternion.AngleAxis(mouseX, Vector3.up) * desiredOffset;
        }

        offset = Vector3.Slerp(offset, desiredOffset, smoothSpeed * Time.deltaTime);
        transform.LookAt(player.transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }

    void Update()
    {


    }
}