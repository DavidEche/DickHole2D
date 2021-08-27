using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothtime = .5f;
    public float minzoom = 40f;
    public float maxzoom = 10f;
    public float zoomlimiter = 50f;

    private Camera cam;

    private Vector3 velocity;

    private void Start()
    {
        cam =transform.GetChild(0).GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
        {return;}
        move();
        zoom();
    }

    void zoom()
    {
       float newzoom = Mathf.Lerp(maxzoom, minzoom, GetGreatestDistance()/ zoomlimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newzoom, Time.deltaTime);
    }


    void move()
    {
        Vector3 centerpoint = findcenter();
        Vector3 newposition = centerpoint + offset + new Vector3(0,0,-GetGreatestDistance());
        transform.position = Vector3.SmoothDamp(transform.position, newposition, ref velocity, smoothtime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x+bounds.size.y;
    }

    Vector3 findcenter()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    } 

}
