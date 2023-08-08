using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallExplosionEffect : MonoBehaviour
{
    private float splashRadius;

    private void Start()
    {
        splashRadius = GetComponentInParent<FireBall>().splashRadius;
        GetComponentInParent<FireBall>().Delete();

        transform.SetParent(null);
        transform.localScale = new Vector3(splashRadius * 2, splashRadius * 2, 1);

        Invoke("Delete", 0.2f);
    }

    private void Delete()
    {
        Destroy(gameObject);
        Destroy(this);
    }
}
