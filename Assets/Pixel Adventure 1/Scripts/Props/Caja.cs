using UnityEngine;

public class Caja : MonoBehaviour
{
    public Animator animator; 
    public SpriteRenderer spriteRenderer;
    public GameObject PartesCaja;
    public float junpForce = 5f; // Fuerza del salto
    public int vida = 1; // Vida de la caja
    public GameObject boxCollider; // Referencia al collider de la caja
    public Collider2D collidercaja; // Referencia al collider2D de la caja

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * junpForce); // Aplicar una fuerza hacia arriba al Rigidbody del jugador
            losseLifeHit(); // Llamar al m�todo para perder vida
        }
    }
    public void losseLifeHit()
    {
        //perder vidas
        vida--;
        if (vida <= 0)
        {
            //activar animacion de romper caja
            animator.SetTrigger("Hit");
            //verificar si tiene vidas
            checkLife();// Llamar al m�todo para verificar la vida

        }
    }
    public void checkLife()
    {
        if (vida <= 0)
        {
            boxCollider.SetActive(false); // Desactivar el collider de la caja
            collidercaja.enabled = false; // Desactivar el collider2D de la caja
            //activar partes de la caja
            PartesCaja.SetActive(true);
            //desactivar el sprite de la caja
            spriteRenderer.enabled = false;
            Invoke("DestroyCaja", 0.5f);// Invocar la funci�n DestroyCaja despu�s de 0.5 segundos
        }
    }
    //funcion para destruir la caja
    public void DestroyCaja()
    {
        Destroy(gameObject);
    }

}
