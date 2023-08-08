using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float power;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public int damage;

    public Transform splashCenter;
    public float splashRadius;
    public GameObject explosionEffect;

    private void Start()
    {
        power = GetComponentInParent<TankShooting>().shootPower;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GetComponentInParent<TankShooting>().color;

        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(power * 2, 0));

        transform.SetParent(null);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<TankHealth>().TakeDamage(damage);
            Delete();
        }

        Collider2D[] inSplashRadius = Physics2D.OverlapCircleAll(splashCenter.position, splashRadius);

        if (inSplashRadius.Length > 0)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation, transform);

            foreach (Collider2D objectCollision in inSplashRadius)
            {
                Explode(inSplashRadius);
                int giveOrTakeDamage = (int)Random.Range((float)damage / 2f, (float)damage / 2f);

                if (objectCollision.gameObject.CompareTag("Player"))
                {
                    objectCollision.gameObject.GetComponent<TankHealth>().TakeDamage((int)(damage + giveOrTakeDamage / (Vector2.Distance(splashCenter.position, objectCollision.transform.position * Vector2.Distance(splashCenter.position, objectCollision.transform.position)))));
                }
            }
        }
    }

    private void Explode(Collider2D[] objects)
    {
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            try
    		{
                obj.GetComponent<Rigidbody2D>().AddForce(direction.normalized * power);
			}
            catch
			{
                //
			}
        }
    }

    public void Delete()
    {
        Destroy(spriteRenderer);
        Destroy(rb);
        Destroy(gameObject);
        Destroy(this);
    }

    private void OnDrawGizmosSelected()
    {
        if (splashCenter == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(splashCenter.position, splashRadius);
    }
}
