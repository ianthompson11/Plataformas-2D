using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ← CAMBIO: usar TextMeshPro
public class CoinsManager : MonoBehaviour
{
    public GameObject levelCleared;  // Imagen o panel de victoria (UI)
    public GameObject transition;    // Imagen/panel de transición (UI)
    public GameObject hudCanvas;     // (Opcional) El HUD que quieres ocultar al ganar

    public TMP_Text totalCoins; // ← CAMBIO aquí
    public TMP_Text CoinsCollected; // ← CAMBIO aquí

    private int totalCoinsInLevel;

    private void Start()
    {
        totalCoinsInLevel = transform.childCount;
    }
    private void Update()
    {
        Debug.Log("Monedas y esmeraldas restantes: " + transform.childCount);
        AllCoinsCollected();
        totalCoins.text = totalCoinsInLevel.ToString();
        CoinsCollected.text=transform.childCount.ToString();
    }

    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan monedas, ¡Victoria!");

            if (hudCanvas != null)
            {
                hudCanvas.SetActive(false); // Desactiva el HUD si lo asignaste
            }

            if (levelCleared != null)
            {
                levelCleared.SetActive(true); // Muestra imagen de victoria
            }
            else
            {
                Debug.LogWarning("No se asignó el objeto 'levelCleared' en el Inspector.");
            }

            if (transition != null)
            {
                transition.SetActive(true); // Muestra panel o animación de transición
            }
            else
            {
                Debug.LogWarning("No se asignó el objeto 'transition' en el Inspector.");
            }

            Invoke("ChangeScene", 2f); // Espera 2 segundos y cambia de escena
        }
    }

    private void ChangeScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Evita error si no hay siguiente escena en Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay una escena siguiente configurada en Build Settings.");
        }
    }
}
