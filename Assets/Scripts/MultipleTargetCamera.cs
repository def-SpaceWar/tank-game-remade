using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime;

    public float minZoom;
    public float maxZoom;

    public float zoomConstant;
    public float zoomSpeed;

    private Vector3 velocity;
    private Camera camera;

	private void Start()
	{
        camera = GetComponent<Camera>();
	}

	private void LateUpdate()
    {
        if (targets.Count == 0)
		{
            return;
		}

        Move();
        Zoom();
    }

    private void Move()
	{
        try
        {
            Vector3 centerPoint = GetCenterPoint();
            transform.position = Vector3.SmoothDamp(transform.position, centerPoint + offset, ref velocity, smoothTime);
        }
        catch
        {
            // When the tank dies its transform is removed so
            // unsecessary errors happen so this is in a try catch block
            return;
        }
    }

    private Vector3 GetCenterPoint()
	{
        if (targets.Count == 1)
		{
            return targets[0].position;
		}

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

		for (int i = 0; i < targets.Count; i++)
		{
            bounds.Encapsulate(targets[i].position);
		}

        return bounds.center;
	}

    private void Zoom()
	{
        try
		{
            float newZoom = Mathf.Lerp(camera.orthographicSize, GetSize() / zoomConstant, zoomSpeed);

            if (newZoom > maxZoom)
			{
                newZoom = maxZoom;
			}
            else if (minZoom > newZoom)
			{
                newZoom = minZoom;
			}

            camera.orthographicSize = newZoom;
		}
		catch
		{
            // When the tank dies its transform is removed so
            // unsecessary errors happen so this is in a try catch block
            return;
		}
	}

    private float GetSize()
	{
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        if (bounds.size.y > (bounds.size.x * 9 / 16))
		{
            return bounds.size.y * 16 / 9;
		}

        return bounds.size.x;
    }
}
