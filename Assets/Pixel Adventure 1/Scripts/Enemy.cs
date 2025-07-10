using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Enemy health: {health}");
        if (health <= 0)
        {
            Die();
        }
        // Opcional: Reproducir animaci�n de da�o
        // GetComponent<Animator>().SetTrigger("Hurt");
    }

    void Die()
    {
        Destroy(gameObject);
        // Opcional: Reproducir animaci�n de muerte antes de destruir
    }
}