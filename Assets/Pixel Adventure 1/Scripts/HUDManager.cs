using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject hudCanvas;

    private void Start()
    {
        // Si no se asignó manualmente, intenta encontrar un objeto con la etiqueta "HUD"
        if (hudCanvas == null)
        {
            GameObject foundHUD = GameObject.FindWithTag("HUD");
            if (foundHUD != null)
            {
                hudCanvas = foundHUD;
            }
            else
            {
                Debug.LogWarning("HUDManager: No se encontró ningún GameObject con la etiqueta 'HUD'. Asigna el hudCanvas manualmente.");
            }
        }
    }

    public void ShowHUD()
    {
        if (hudCanvas != null)
        {
            hudCanvas.SetActive(true);
        }
    }

    public void HideHUD()
    {
        if (hudCanvas != null)
        {
            hudCanvas.SetActive(false);
        }
    }
}

