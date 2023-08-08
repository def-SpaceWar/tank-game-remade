using UnityEngine;

class ProjectileBox : MonoBehaviour
{
    public GameObject projectile;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TankShooting tankShooter;

        try
        {
            tankShooter = collision.gameObject.GetComponentInChildren<TankShooting>();
        }
        catch
        {
            try
            {
                tankShooter = collision.gameObject.GetComponent<TankShooting>();
            }
            catch
            {
                return;
            }
        }

        tankShooter.projectile = projectile;

        Destroy(gameObject);
        Destroy(this);
    }
}