using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject creditsUI;

    public GameObject[] credits;
    static int curPage = 0;
    public void OnXButton()
    {
        mainMenuUI.SetActive(true);
        creditsUI.SetActive(false);
    }

    void Update()
    {
        credits[curPage].SetActive(true);
    }

    public void LeftButton()
    {
        if(curPage > 0)
        {
            credits[curPage].SetActive(false);
            curPage--;
        }
    }

    public void RightButton()
    {
        if (curPage < credits.Length - 1)
        {
            credits[curPage].SetActive(false);
            curPage++;
        }
    }
    
}
