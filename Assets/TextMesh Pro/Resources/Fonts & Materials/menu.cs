using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject menuPanel;

    // IKAKABIT SA START BUTTON
    public void StartGame()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }

        Time.timeScale = 1f;
        Debug.Log(">>> NAGSIMULA NA ANG LARO <<<");
    }

    // IKAKABIT SA QUIT BUTTON
    public void QuitGame()
    {
        Debug.Log(">>> LUMABAS SA LARO <<<");
        Application.Quit();
    }
}