using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    public Vector2 m_Size;
    public Vector2 m_Center;
    public float seconds;
    private Vector3 m_movementPos;

    private void OnEnable()
    {
        StartCoroutine(FloatAround(seconds));
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, m_movementPos, 0.05f);
    }

    private IEnumerator FloatAround(float _time)
    {
        yield return new WaitForSeconds(1);
        while (_time > 0)
        {
            m_movementPos = new Vector3(Random.Range(-m_Size.x, m_Size.x), Random.Range(-m_Size.y, m_Size.y), 0);
            _time--;
        }

        StartCoroutine(FloatAround(seconds));
    }
}
