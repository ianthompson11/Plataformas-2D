using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public TextMeshProUGUI levelCleared;

    public GameObject transition;


    private void Update()
    {
        AllCoinsCollected();
    }

    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan monedas, ¡Victoria!");

            if (levelCleared != null)
            {
                levelCleared.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No se asignó el objeto 'levelCleared' en el Inspector.");
            }
            transition.SetActive(true);


            Invoke("ChangeScene", 2f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

