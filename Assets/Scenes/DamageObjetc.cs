using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");

            // Si solo quieres destruir este objeto (el que tiene este script)
            // Usa Destroy(gameObject);
            // Si realmente deseas destruir el jugador:
            Destroy(collision.gameObject);
        }
    }
}