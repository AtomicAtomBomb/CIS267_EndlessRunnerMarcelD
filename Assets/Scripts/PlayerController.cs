using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int movementSpeed;
    private int numJumps;
    private int maxNumJumps = 2;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private Animator playerAnimator;
    public float jumpForce;
    public GameObject speedPowerup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
        fallDown();
    }

    private void movePlayerLateral()
    {
        inputHorizontal = 1;
        rb.linearVelocity = new Vector2(movementSpeed * inputHorizontal, rb.linearVelocityY);

        if (inputHorizontal != 0)
        {
            playerAnimator.SetBool("isWalking", true);
            flipPlayerSprite(inputHorizontal);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void flipPlayerSprite(float ih)
    {
        if (ih > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (ih < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps < maxNumJumps)
        {
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            numJumps++;
        }
    }

    private void fallDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 5;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("isJumping", false);
            numJumps = 0;
        }

        if (collision.gameObject.CompareTag("Shuriken"))
        {
            SceneManager.LoadScene("Level");
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene("Level");
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            SceneManager.LoadScene("Level");
        }

        if (collision.gameObject.CompareTag("OB"))
        {
            SceneManager.LoadScene("Level");
        }

        if (collision.gameObject.CompareTag("SpeedPowerup"))
        {
            movementSpeed = 15;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BigJumpPowerup"))
        {
            jumpForce = 15;
            Destroy(collision.gameObject);
        }
    }
}
