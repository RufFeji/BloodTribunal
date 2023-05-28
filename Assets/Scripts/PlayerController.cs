using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float moveInput;

    private Rigidbody2D rb;
    private SpriteRenderer _renderer;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator animator;
    private string currentState;

    //Animation states
    const string Idle = "Idle";
    const string Walk = "Walk";

    private DialogueRunner dialogueRunner = null; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (dialogueRunner.IsDialogueRunning == true)
        //    return; –¿— ŒÃ≈Õ“»–Œ¬¿“‹ œŒ“ŒÃ

        if (moveInput < 0 && speed != 0 || moveInput > 0 && speed != 0)
        {
            ChangeAnimationState(Walk);
        }
        else
            ChangeAnimationState(Idle);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (moveInput > 0 && speed == 5)
        {
            _renderer.flipX = false;
        }
        else if (moveInput < 0 && speed == 5)
        {
            _renderer.flipX = true;
        }
    }

    public void stopPlayer()
    {
        Debug.Log("stop");
        speed = 0;
        ChangeAnimationState(Idle);
    }

    public void movePlayer()
    {
        Debug.Log("move");
        speed = 5;
    }
}

