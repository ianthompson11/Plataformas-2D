using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Si mantienes presionado el clic izquierdo, activa el ataque
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}




