using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Vector2 force;
            force = Vector2FromAngle(transform.rotation.z) * jumpPower;

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
        catch
        {
            //
        }
    }

    Vector2 Vector2FromAngle(float angle)
	{
        if (angle == 0)
		{
            angle += 90;
		}

        angle *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}
}
