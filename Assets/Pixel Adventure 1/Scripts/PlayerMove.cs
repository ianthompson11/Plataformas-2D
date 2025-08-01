﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Animator animator;
    public Collider2D attackHitbox;
    public float attackDamage = 20f;

    public float runSpeed = 2f;
    public float jumpSpeed = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    public bool betterJump = true;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private bool isJumpPressed;
    private bool isAttackPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputActions = new PlayerInputActions();

        if (attackHitbox != null)
        {
            attackHitbox.enabled = false;
        }
    }

    void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerInputActions();
        }

        inputActions.Enable();

        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Move.canceled += _ => moveInput = Vector2.zero;

        inputActions.Gameplay.Jump.performed += _ => isJumpPressed = true;
        inputActions.Gameplay.Jump.canceled += _ => isJumpPressed = false;

        inputActions.Gameplay.Attack.performed += _ => isAttackPressed = true;
        inputActions.Gameplay.Attack.canceled += _ => isAttackPressed = false;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * runSpeed, rb.linearVelocity.y);

        if (moveInput.x > 0.01f)
        {
            spriteRenderer.flipX = false;
            attackHitbox.transform.localPosition = new Vector2(0f, 0f);
        }
        else if (moveInput.x < -0.01f)
        {
            spriteRenderer.flipX = true;
            attackHitbox.transform.localPosition = new Vector2(-0.22f, 0f);
        }

        // Animación de caída
        if (!IsGrounded() && rb.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        // Animación de salto
        if (!IsGrounded())
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // Animación de correr
        if (Mathf.Abs(moveInput.x) > 0.01f && IsGrounded())
        {
            animator.SetBool("Run", true);
        }
        else if (IsGrounded())
        {
            animator.SetBool("Run", false);
        }

        // Animación de ataque
        animator.SetBool("Attack", isAttackPressed);

        // Salto
        if (isJumpPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }

        // Better Jump
        if (betterJump)
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if (rb.linearVelocity.y > 0 && !isJumpPressed)
            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void EnableAttackHitbox()
    {
        if (attackHitbox != null)
        {
            attackHitbox.enabled = true;
        }
    }

    public void DisableAttackHitbox()
    {
        if (attackHitbox != null)
        {
            attackHitbox.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && attackHitbox.enabled)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
