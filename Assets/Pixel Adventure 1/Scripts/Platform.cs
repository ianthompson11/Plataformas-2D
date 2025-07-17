using UnityEngine;

public class Platform : MonoBehaviour
{
    //efecto de plataforma
    private PlatformEffector2D effector;
    public float starwaitTime; // Tiempo de espera antes de permitir el paso
    private float waitedTime; // Tiempo transcurrido desde que se activó el efecto


    // This class is empty but can be used to add platform-specific functionality later

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();// Obtiene el componente PlatformEffector2D del GameObject

    }

    // Update is called once per frame
    void Update()
    {
        //resetear el tiempo de espera en el momento en que se suelta la tecla s o space
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            waitedTime = starwaitTime; // Reinicia el tiempo de espera

        }

        //cambiar el angulo de la plataforma cuando vamos hacia abajo segun el tiempo que se ha presionado la tecla S
        if (Input.GetKey(KeyCode.S))
        {
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180f; // Cambia el ángulo de la plataforma
                waitedTime = starwaitTime; // Reinicia el tiempo de espera
            }
            else//aumenta el tiempo de espera
            {
                waitedTime -= Time.deltaTime; // Disminuye el tiempo de espera
            }
        }
        //ver si se presiona el salto y poner la plataforma en su estado normal
        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0f; // Cambia el ángulo de la plataforma a su estado normal
            waitedTime = 0; // Reinicia el tiempo de espera
        }
    }
}
