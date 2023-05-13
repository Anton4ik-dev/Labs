using UnityEngine.SceneManagement;

namespace Service
{
    public static class RestartService
    {
        public static void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}