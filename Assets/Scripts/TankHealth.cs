using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int health = 100;
    public Slider healthBar;

    public bool dead;

    public GameObject winScreen;

    // Start is called before the first frame update
    private void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    private void Update()
    {
        healthBar.value = health;

        if (health <= 0)
        {
            dead = true;
        }

        if (dead)
        {
            Destroy(healthBar.gameObject);
            Destroy(GetComponentInChildren<TankShooting>().shootPowerSlider.gameObject);
            Destroy(gameObject);
        }

        var temp = FindObjectsOfType<TankHealth>();

        if (temp.Length == 1)
        {
            Win();
        }

        if (temp.Length == 0)
        {
            Win();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Win()
    {
        winScreen.SetActive(true);

        GetComponent<TankMovement>().jammed = true;
        GetComponentInChildren<TankShooting>().jammed = true;
    }
}
