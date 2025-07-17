using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //referencial al public animator
    public Animator animator;
    public float jumpForce = 5f; // Fuerza del salto

    //sistema de deteccion de colision con el player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //preguntar si se choco con el tag Player
            if(collision.transform.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * jumpForce);// Aplicar una fuerza hacia arriba al Rigidbody del jugador
                //activar animacion de salto
                animator.SetTrigger("Jump");
            }

        }
    }
}

