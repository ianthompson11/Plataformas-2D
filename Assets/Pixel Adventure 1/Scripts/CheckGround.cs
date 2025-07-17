using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)// This method is called when the collider enters the trigger
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)// This method is called when the collider exits the trigger
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // isGrounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = false;
    }
}
