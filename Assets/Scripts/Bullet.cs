
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health health = hitInfo.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
