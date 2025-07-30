using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float moveSpeed;
    public float jumpSpeed;
    private bool isJumping = false;
    private bool isPunching = false;
    private bool isPressingButton = false;
    private bool isInteracting = false; 
    public float punchTime = 0.5f;
    public float interactTime = 1f;

    public Material defaultButtonMat;
    public Material activeButtonMat;
    private AN_Button currentColourButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        PlayerMovement();

        if (Input.GetButtonDown("Jump"))
        {
            // StartCoroutine(Jump());
            Jump();
        }

        if (Input.GetButtonDown("Punch"))
        {
            StartCoroutine(Punch());
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (isInteracting)
                StartCoroutine(PressButton());
        }

        if (Input.GetButtonDown("Shuffle"))
        {
            FindObjectOfType<Automate>().Shuffle();
        }

        if (Input.GetButtonDown("Submit"))
        {
            FindObjectOfType<MenuManager>().ReturnToMainMenu();
        }
    }

    private void PlayerMovement()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horz, 0f, vert) * moveSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Mathf.Abs(playerMovement.x) == 1 || Mathf.Abs(playerMovement.z) == 1)
        {
            anim.SetFloat("LastXDirection", playerMovement.x);
            anim.SetFloat("LastZDirection", playerMovement.z);
        }

        // Animation
        anim.SetFloat("Horizontal", playerMovement.x);
        anim.SetFloat("Vertical", playerMovement.z);
        anim.SetFloat("Speed", playerMovement.sqrMagnitude);

    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
        isJumping = true;
        // TODO: Play jumping sound
        // AudioManager.Instance.PlayJumpSound();
        // anim.SetFloat("Jump", rb.velocity.y);
        //yield return new WaitForSeconds(jumpSpeed);
        //isJumping = false;
        //anim.SetBool("Jump", isJumping);
    }

    IEnumerator Punch()
    {
        isPunching = true;
        // TODO: Play punching sound
        // AudioManager.Instance.PlayPunchSound();
        anim.SetBool("Punch", isPunching);
        Debug.Log("PUNCH!");
        yield return new WaitForSeconds(punchTime);
        isPunching = false;
        anim.SetBool("Punch", isPunching);
    }

    IEnumerator PressButton()
    {
        isPressingButton = true;
        // TODO: Play Interact animation
        anim.SetBool("Interact", isPressingButton);
        yield return new WaitForSeconds(interactTime);
        currentColourButton.Press();
        isPressingButton = false;
        anim.SetBool("Interact", isPressingButton);
    }

    private void OnTriggerEnter(Collider other)
    {
        isInteracting = true;
        if (other.CompareTag("ColourButton"))
        {
            currentColourButton = other.gameObject.GetComponent<AN_Button>();
            other.transform.parent.GetComponent<MeshRenderer>().material = activeButtonMat;
            /*
            if (Input.GetButtonDown("Interact"))
            {
                other.gameObject.GetComponent<AN_Button>().Press();
            }
            */
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInteracting = false;
        if (other.CompareTag("ColourButton"))
        {
            other.transform.parent.GetComponent<MeshRenderer>().material = defaultButtonMat;
        }

    }

}
