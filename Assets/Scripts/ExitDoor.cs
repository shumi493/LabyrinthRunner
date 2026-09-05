using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameManager gameManager;
    public Sprite lockedSprite;
    public Sprite unlockedSprite;
    private SpriteRenderer spriteRenderer;
    private bool isUnlocked = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (lockedSprite != null)
            spriteRenderer.sprite = lockedSprite;
    }

    void Update()
    {
        // Check if player has all 3 keys (300 points = 3 keys)
        if (!isUnlocked && gameManager.score >= 300)
        {
            isUnlocked = true;
            if (unlockedSprite != null)
                spriteRenderer.sprite = unlockedSprite;
            Debug.Log("Door Unlocked!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isUnlocked)
        {
            gameManager.WinGame();
        }
    }
}