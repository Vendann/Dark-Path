using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : Entity
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float respawnX = -6f;
    [SerializeField] private float respawnY = -3f;
    [SerializeField] private AudioSource portal;
    [SerializeField] private AudioSource spike;

    private bool isGrounded = true;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public static Player Instance { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovingPlatform" || collision.collider.tag == "VertMovingPlatform" || collision.collider.tag == "SuperPlatform")
            this.transform.parent = collision.transform;
        if (collision.collider.tag == "Spike")
            spike.Play();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        if (collision.collider.tag == "MovingPlatform" || collision.collider.tag == "VertMovingPlatform" || collision.collider.tag == "SuperPlatform")
            this.transform.parent = null;
    }

    public override void GetDamage()
    {
        transform.position = new Vector3(respawnX, respawnY, 0);
    }

    public void Teleport(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        portal.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(4);
    }
}