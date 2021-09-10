using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] m_Plataformas;
    [SerializeField] GameObject platformParent;
    public float m_SpawnRate;
    public float m_PlatformSpeed;
    public bool m_CanSpawn=true;
    

    private void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
            StartCoroutine(Spawn(m_SpawnRate));

    }

    private IEnumerator Spawn(float rate)
    {
        while (rate != 0)
        {
            yield return new WaitForSeconds(rate);
            GameObject platClone = new GameObject();
            platClone.transform.parent = gameObject.transform;
            platClone = Instantiate(m_Plataformas[GenerateRandomId()], this.transform.position, Quaternion.identity, platformParent.transform);
            platClone.GetComponent<PlatformRotate>().speed = m_PlatformSpeed;
            Destroy(platClone, 10);
            rate--;

        }
        if (rate == 0 && m_CanSpawn)
        {
            rate = m_SpawnRate;
            StartSpawn();
        }
    }

    public int GenerateRandomId()
    {
        int randID = Random.Range(0, m_Plataformas.Length);
        return randID;
    }
}
