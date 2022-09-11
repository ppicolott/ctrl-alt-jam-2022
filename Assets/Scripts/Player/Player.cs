using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform footTransform;
	
    [Space(10)]
    [Header("Particles")]
    [Space(5)] 
    [SerializeField] private ParticleSystem dustParticle;
    [SerializeField] private ParticleSystem steamParticle;

    private Rigidbody2D rb;
    private Animator animator;
    private float speed;
    private float growthSpeed;

    private bool availableJumping;
    private string facingDirection;

    private float bufferTime;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    // Input System
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.speed = 18f; // 3f;
        this.bufferTime = 0.2f;
        this.facingDirection = "Left";
        this.availableJumping = true;

        this.playerInput = GetComponent<PlayerInput>();
        this.moveAction = this.playerInput.actions["Move"];
        this.jumpAction = this.playerInput.actions["Jump"];
    }
    void FixedUpdate() // Update()
    {
        Move();
        Jump();
        Growth();
        Died();
        Gravity();
        Animation();
        Particle();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Hot":
                this.growthSpeed = -0.05f;
                break;
            case "Very Hot":
                this.growthSpeed = -0.15f;
                break;
            case "Cold":
                this.growthSpeed = 0.2f;
                break;
            default:
                this.growthSpeed = 0;
                break;
        }

        if (collision.gameObject.name.Equals("Ladder"))
        {
            LadderSFX.current.ladderSFX.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.growthSpeed = 0;
    }
    private void Move()
    {
        float horizontal = this.moveAction.ReadValue<Vector2>().x;
        float velocityX = this.rb.velocity.x;

        if (horizontal != 0)
        {
            velocityX += horizontal * this.speed * 0.01f;

            if (this.rb.velocity.x <= -this.speed || this.rb.velocity.x >= this.speed)
            {
                velocityX = horizontal * this.speed;
            }

            this.rb.velocity = new Vector2(velocityX, this.rb.velocity.y);

            // Virar horizontalmente
            this.transform.localScale = new Vector3((-horizontal > 0 ? 1 : -1) * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    private void Jump()
    {
        // Gerenciar o tempo para o salto Coyote
        if (Physics2D.OverlapBox(this.footTransform.position, new Vector2(0.6f, 0.05f), 0f, this.groundLayer))
        {
            this.coyoteTimeCounter = this.bufferTime;
        }
        else
        {
            this.coyoteTimeCounter = this.coyoteTimeCounter < 0f ? 0f : this.coyoteTimeCounter -= Time.deltaTime;
        }

        // Gerenciar o tempo para o Jump Buffer
        this.jumpBufferCounter = this.jumpBufferCounter < 0f ? 0f : this.jumpBufferCounter -= Time.deltaTime;
        this.jumpAction.performed += context => this.jumpBufferCounter = this.bufferTime;

        if (this.coyoteTimeCounter > 0f && this.jumpBufferCounter > 0f && this.availableJumping)
        {
            float jumpVelocity = 7f * this.transform.localScale.y;
            this.rb.velocity = new Vector2(this.rb.velocity.x, jumpVelocity < 5f ? 5f : jumpVelocity);
            StartCoroutine(JumpCooldown());
        }

        this.jumpAction.canceled += context => {
            if (this.rb && this.rb.velocity.y > 0f)
            {
                this.rb.velocity = new Vector2(this.rb.velocity.x, this.rb.velocity.y * 0.5f); // Height jump
            }
        };
    }
    private void Growth()
    {
        if (this.growthSpeed != 0)
        {
            if (!this.steamParticle.isPlaying && this.growthSpeed < 0)
            {
                this.steamParticle.Play();
            }
            ManagerStates.life += this.growthSpeed * Time.deltaTime;

            if(ManagerStates.life >= 1f)
            {
                ManagerStates.life = 1f;
            }
            else if(ManagerStates.life <= 0f)
            {
                ManagerStates.life = 0f; 
			}
        }
        else
        {
            this.steamParticle.Stop();
        }
        this.transform.localScale = new Vector3((this.transform.localScale.x > 0f ? ManagerStates.life : -ManagerStates.life), ManagerStates.life, 1f); 
    }
    private void Gravity()
    {
        this.rb.velocity += Vector2.up * Physics2D.gravity.y * 1f * Time.deltaTime;
    }
    private void Died()
    {
        if (ManagerStates.life <= 0f)
        {
            ManagerStates.life = 1f;
			SceneManager.LoadScene("GameOver");
        }
    }
    private void Animation()
    {
        this.animator.SetBool("isWalking", this.moveAction.ReadValue<Vector2>().x != 0);
        this.animator.SetBool("isJumping", !Physics2D.OverlapBox(this.footTransform.position, new Vector2(0.6f, 0.05f), 0f, this.groundLayer));
    }
    private void Particle()
    {
        if (Mathf.Round(this.rb.velocity.y) == 0f)
        {
            if (Mathf.Round(this.rb.velocity.x) < 0f)
            {
                if (this.facingDirection == "Right")
                {
                    this.facingDirection = "Left";
                    dustParticle.Play();
                }
            }
            else if (Mathf.Round(this.rb.velocity.x) > 0f)
            {
                if (this.facingDirection == "Left")
                {
                    this.facingDirection = "Right";
                    dustParticle.Play();
                }
            }
        }
    }
    private IEnumerator JumpCooldown()
    {
        this.availableJumping = false;
        this.dustParticle.Play();
        yield return new WaitForSeconds(0.4f);
        this.availableJumping = true;
    }
}