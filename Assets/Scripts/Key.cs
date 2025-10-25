using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    static bool hasKey = false;
    public GameObject keySprite;


    private void Start()
    {
        doorAnim = door.GetComponent<Animator>();
        doorAnim.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);

            hasKey = true;
        }

        if (other.gameObject.CompareTag("Door") && hasKey == true)
        {
            doorAnim.enabled = true;
        }
    }

    private void Update()
    {
        if (hasKey == false)
        {
            keySprite.SetActive(false);
        }
        else
        {
            keySprite.SetActive(true);
        }
    }
}
