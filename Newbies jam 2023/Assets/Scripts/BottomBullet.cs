using UnityEngine;

public class BottomBullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    public bool isEnemyBullet;

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isEnemyBullet == true)
            {
                playerHealth.TakeDamage(1);
            }
            
        }
    }
}
