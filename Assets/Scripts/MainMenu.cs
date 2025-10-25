using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject creditsUI;
    public GameObject controlUI;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnControlButton()
    {
        mainMenuUI.SetActive(false);
        controlUI.SetActive(true);
    }

    public void OnCreditButton()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
        controlUI.SetActive(false);
    }
}
