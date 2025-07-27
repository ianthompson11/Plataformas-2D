using UnityEngine;


public class ObjectCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            // Si este objeto es una poción
            if (gameObject.CompareTag("Potion"))
            {
                collision.GetComponent<PlayerRespawn>().HealPlayer();
            }
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            
            Destroy(gameObject, 0.5f);
        }
    }

}
