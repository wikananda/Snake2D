using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }

    public void BeginPlay()
    {
        SceneManager.LoadScene("Snake");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
