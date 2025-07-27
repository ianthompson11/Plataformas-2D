using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;

    // Unity Message | 0 references
    void Start()
    {
        life = hearts.Length;
        //Borrar checkpoint para iniciar desde el principio
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");

        if (PlayerPrefs.HasKey("checkPointPositionX") && PlayerPrefs.HasKey("checkPointPositionY"))
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    // 1 reference


    // Unity Message | 0 references
    private void CheckLife()
    {
        if (life > 0)
        {
            Respawn(); // Vuelve al checkpoint
            animator.Play("Hit");
            hearts[life].SetActive(false); // Destruye el corazón correspondiente

        }
        else
        {
            // Se quedó sin vidas → borrar checkpoint y reiniciar
            PlayerPrefs.DeleteKey("checkPointPositionX");
            PlayerPrefs.DeleteKey("checkPointPositionY");

            // Se quedó sin vidas → reiniciar nivel o Game Over
            hearts[0].SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    // 2 references
    public void PlayerDamaged()
    {
        //animator.Play("Hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        life--;
        CheckLife();

    }

    private void Respawn()
    {
        // Mueve al jugador a la última posición guardada (checkpoint)
        transform.position = new Vector2(
            PlayerPrefs.GetFloat("checkPointPositionX"),
            PlayerPrefs.GetFloat("checkPointPositionY")
        );
    }
    //Sanando al jugador
    public void HealPlayer()
    {
        if (life < hearts.Length)
        {
            hearts[life].SetActive(true); // Reactiva el corazón
            life++;
        }
        else
        {
            Debug.Log("Vida al máximo, no se puede curar más");
        }
    }
}