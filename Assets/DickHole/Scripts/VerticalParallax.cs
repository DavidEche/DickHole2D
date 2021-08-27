using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalParallax : MonoBehaviour
{
    public float m_BgSpeed;
    public float m_BgLimit;
    private Vector3 m_BgStartPos;

    void Start()
    {
        m_BgStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.up * m_BgSpeed * Time.deltaTime);
        //loop
        if (transform.position.y > m_BgLimit)
        {
            transform.position = m_BgStartPos;
        }
    }
}
