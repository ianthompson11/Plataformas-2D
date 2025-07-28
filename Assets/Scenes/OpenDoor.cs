using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public TMP_Text text; // Cambiado para TextMeshPro
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // corregido 'Collision' a 'collision'
        {
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKeyDown(KeyCode.E)) // mejor con GetKeyDown
        {
            SceneManager.LoadScene(levelName); // corregido para usar levelName
        }
    }
}
