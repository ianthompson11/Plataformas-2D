using UnityEngine;

public class UIHeartFollow : MonoBehaviour
{
    public Transform target; // El jugador
    public Vector3 offset;   // Ajusta si quieres los corazones encima o a un lado
    public Canvas canvas;

    private RectTransform rectTransform;
    private Camera mainCamera;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position + offset);
        rectTransform.position = screenPos;
    }
}

