
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject player;

    public HealthBar healthBar;

    public GameObject gameOverUIp1Win;

    public GameObject gameOverUIp2Win;

    public GameManagerScript gameManager;
    private bool isDead;

    public AudioSource Music;

    void Start()
    {
        player = this.gameObject;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        if(this.gameObject.tag == "Player2")
        {
            gameOverUIp1Win.SetActive(true);
        }

        if (this.gameObject.tag == "Player")
        {
            gameOverUIp2Win.SetActive(true);
        }

        isDead = true;
        Destroy(gameObject);
    }
}
