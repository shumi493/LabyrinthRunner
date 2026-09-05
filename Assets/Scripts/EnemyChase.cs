using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public GameManager gameManager;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameManager.gameEnded)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.PlayerHit();
        }
    }
}