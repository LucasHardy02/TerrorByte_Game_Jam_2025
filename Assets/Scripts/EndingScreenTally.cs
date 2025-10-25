using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreenTally : MonoBehaviour
{
    public GameObject finalTally;

    private int enemiesKilled;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
