using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensAndSettings : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}