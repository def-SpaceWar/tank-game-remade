using Unity.Profiling;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int tankNum;

    public string moveLeft;
    public string moveRight;
    public float movePower;

    public Transform[] groundCheckPoints;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    public string angleUpKey;
    public string angleDownKey;
    public float angleMove;
    public float minAngle;
    public float maxAngle;
    public Transform TankShooter;

    private Rigidbody2D rb;

    public bool jammed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.GetString("player1up") == "")
        {
            Controls.ErrorResetControls();
        }

        if (tankNum == 1)
        {
            moveLeft = PlayerPrefs.GetString("player1left");
            moveRight = PlayerPrefs.GetString("player1right");
            angleUpKey = PlayerPrefs.GetString("player1up");
            angleDownKey = PlayerPrefs.GetString("player1down");
        }
        else if (tankNum == 2)
        {
            moveLeft = PlayerPrefs.GetString("player2left");
            moveRight = PlayerPrefs.GetString("player2right");
            angleUpKey = PlayerPrefs.GetString("player2up");
            angleDownKey = PlayerPrefs.GetString("player2down");
        }
    }

    private void Update()
    {
        isGrounded = false;

        foreach (Transform groundCheckPoint in groundCheckPoints)
        {
            Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundCheckPoint.position, groundCheckRadius, groundLayer);

            if (groundObjects.Length > 0)
            {
                isGrounded = true;
            }
        }

        if (!jammed)
        {
            if (Input.GetKey(moveLeft))
            {
                if (rb.gravityScale != 0)
                {
                    if (isGrounded)
                    {
                        rb.AddRelativeForce(new Vector3(-movePower * Time.deltaTime, 0, 0));
                    }
                }
                else
                {
                    rb.AddRelativeForce(new Vector3(-movePower * Time.deltaTime, 0, 0));
                }
            }
            else if (Input.GetKey(moveRight))
            {
                if (rb.gravityScale != 0)
                {
                    if (isGrounded)
                    {
                        rb.AddRelativeForce(new Vector3(movePower * Time.deltaTime, 0, 0));
                    }
                }
                else
                {
                    rb.AddRelativeForce(new Vector3(movePower * Time.deltaTime, 0, 0));
                }
            }

            if (Input.GetKey(angleDownKey))
            {
                TankShooter.Rotate(0f, 0f, -angleMove);
            }
            else if (Input.GetKey(angleUpKey))
            {
                TankShooter.Rotate(0f, 0f, angleMove);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Transform groundCheckPoint in groundCheckPoints)
        {
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
