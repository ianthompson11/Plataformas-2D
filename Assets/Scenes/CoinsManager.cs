using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinsManager : MonoBehaviour
{
    private void Update()
    {
        AllCoinsCollected();
    }
   public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan monedas, ¡Victoria!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
