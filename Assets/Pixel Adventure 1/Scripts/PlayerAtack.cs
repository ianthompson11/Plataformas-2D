using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public void Attack()
    {
        if (animator.GetBool("IsAttacking")) return; // Si ya está atacando, no hace nada

        animator.SetBool("IsAttacking", true);
        animator.SetTrigger("Attack");
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false);
    }
}



