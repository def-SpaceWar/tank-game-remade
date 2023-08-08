using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KillTank : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
            TankHealth tankHealth;

            try
			{
                tankHealth = collision.gameObject.GetComponent<TankHealth>();
			}
            catch
			{
                tankHealth = collision.gameObject.GetComponentInParent<TankHealth>();
            }

            tankHealth.health = 0;
        }
	}
}
