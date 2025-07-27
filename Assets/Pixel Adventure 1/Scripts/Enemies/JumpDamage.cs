using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;

    public Animator animator;
    public SpriteRenderer spriterenderer;
    public GameObject destroyParticle;

    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * jumpForce);
            LosselifeAndHit();
            CheckLife();
        }
    }

    public void LosselifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriterenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }



}
