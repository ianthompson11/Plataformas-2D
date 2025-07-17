using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");

            // Destruye el objeto del jugador
            Destroy(collision.gameObject);
        }
    }
}