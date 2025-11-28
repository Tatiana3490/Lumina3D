using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Nombre de la escena del nivel
    public string levelSceneName = "Level1";

    public void StartGame()
    {
        // Asegurarnos de que el tiempo vuelve a la normalidad
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
