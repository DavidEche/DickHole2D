using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    void Update()
    {
        //transform.Rotate(0,0,360 *speed * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
