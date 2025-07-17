using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    
    public float speed = 0.5f;
    private float waitTime;
    public Transform[] moveSpots;
    public float startWaitTime = 2;
    private int i = 0;
   

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform); // Make the player a child of the platform
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(RemoveParentNextFrame(collision.collider.transform));
    }

    private System.Collections.IEnumerator RemoveParentNextFrame(Transform child)
    {
        yield return null; // Espera un frame
        if (child != null)
        {
            child.SetParent(null);
        }
    }
}
