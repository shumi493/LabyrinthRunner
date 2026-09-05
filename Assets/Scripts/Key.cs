using UnityEngine;

public class Key : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectKey();
            Destroy(gameObject);
        }
    }
}