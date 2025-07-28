using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public string levelToLoad = "Level - 1"; // Cambia por tu primer nivel
    public GameObject optionsPanel;
    public GameObject creditsPanel;


    public void PlayGame()
    {
        Time.timeScale = 1;// Esto se usa para que el juego no quede congelado, sino que siga avanzando
        SceneManager.LoadScene(levelToLoad);
    }

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void AnotherOptions()
    { 
        //Sounds
        //Grafics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() //Esto solo va a funcionar cuando saquemos el ejecutable del juego 
    { 
        Application.Quit();
    }

    public void OpenCredits()
    {
        optionsPanel.SetActive(false);  // Oculta el panel de opciones
        creditsPanel.SetActive(true);   // Muestra el panel de créditos
    }


    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(true);  // Si quieres volver al panel de opciones
    }

}
