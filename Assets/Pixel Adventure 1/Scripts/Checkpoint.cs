using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);

            GetComponent<Animator>().enabled = true;



        }
    }
}
