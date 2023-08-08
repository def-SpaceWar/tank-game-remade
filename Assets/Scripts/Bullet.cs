using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float power;
    public float despawnTime;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public int damage;

    private void Start()
    {
        power = GetComponentInParent<TankShooting>().shootPower;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GetComponentInParent<TankShooting>().color;

        Invoke("Delete", despawnTime);

        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(power * 2, 0));
        transform.SetParent(null);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TankHealth>().TakeDamage(damage);
        }
    }

    private void Delete()
    {
        Destroy(spriteRenderer);
        Destroy(rb);
        Destroy(gameObject);
    }
}
