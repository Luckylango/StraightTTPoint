using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{

    private float horizontal;
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;

    public Animator animator;

    private bool isJumping;
    private int maxJumps = 5;
    private int remainingJumps;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    private Vector2 _moveDirection;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference dash;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        _moveDirection = move.action.ReadValue<Vector2>();

        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");


        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            remainingJumps = maxJumps;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || (isJumping && remainingJumps > 0))
            {
                isJumping = true;
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                remainingJumps--;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }



}
