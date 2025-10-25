using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 67) * Time.deltaTime);
    }
}
