using UnityEngine;

public class Buttons : MonoBehaviour
{
    static int buttonsPushed;
    public GameObject ladder;
    public Animator ladderAnim;

    private void Start()
    {
        ladderAnim.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            other.gameObject.SetActive(false);
            buttonsPushed++;
        }
    }

    private void Update()
    {
        if (buttonsPushed == 2)
        {
            ladderAnim.enabled = true;
        }
    }
}
