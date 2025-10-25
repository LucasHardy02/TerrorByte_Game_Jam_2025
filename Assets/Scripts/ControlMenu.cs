using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject controlUI;
    public void OnXButton()
    {
        mainMenuUI.SetActive(true);
        controlUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
