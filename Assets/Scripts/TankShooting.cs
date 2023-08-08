using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int tankNum;

    public string shootKey;
    public float shootConstant;
    public float shootPower;
    public Slider shootPowerSlider;
    public Transform shootPoint;
    public GameObject projectile;

    public float shootPauseTime;
    private float shootTimeLeft;

    public Color color;

    public bool jammed = false;

    private void Start()
    {
        shootTimeLeft = shootPauseTime;

        if (PlayerPrefs.GetString("player1up") == "")
        {
            Controls.ErrorResetControls();
        }

        if (tankNum == 1)
        {
            shootKey = PlayerPrefs.GetString("player1shoot");
        }
        else if (tankNum == 2)
        {
            shootKey = PlayerPrefs.GetString("player2shoot");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!jammed)
        {
            shootPower = shootPowerSlider.value * shootConstant;

            if (Input.GetKey(shootKey) && shootTimeLeft <= 0)
            {
                projectile.GetComponent<Transform>();

                Instantiate(projectile, shootPoint.position, transform.rotation, transform);

                shootTimeLeft = shootPauseTime;
            }

            if (shootTimeLeft < 0)
            {
                shootTimeLeft = 0;
            }
            else
            {
                shootTimeLeft -= Time.deltaTime;
            }
        }
    }
}
