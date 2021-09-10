using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    
    [Header("Base Platforms")]
    [SerializeField] private GameObject m_Base;
    [SerializeField] private GameObject m_DickBase;

    [Header("Spawners")]
    [SerializeField] private PlataformSpawner rSpawn;
    [SerializeField] private PlataformSpawner lSpawn;
    [SerializeField] private GameObject m_PlatformParent;
    [SerializeField] private GameObject m_PowerUp;

    private Rigidbody2D _BaseRb;
    private Rigidbody2D m_PlatformParentRb;
    private int timer = 30;

    private void Start() {
        m_PlatformParentRb = m_PlatformParent.GetComponent<Rigidbody2D>();
        _BaseRb = m_Base.GetComponent<Rigidbody2D>();
        StartCoroutine(TimerGame());
    }

    private void Update()
    {
        CheckGameOver();
        SpawnPowerUp();

    }


    public void SpawnPowerUp()
    {
        if (timer <= 15)
        {
            m_PowerUp.SetActive(true);
        }
    }

    private void CheckGameOver()
    {
        if (timer == 0)
        {
            m_Base.GetComponent<Animator>().enabled = false;
            _BaseRb.bodyType = RigidbodyType2D.Dynamic;
            m_PlatformParentRb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(m_Base, 0.75f);
            Destroy(m_PlatformParent, 0.75f);
            lSpawn.m_CanSpawn = false;
            rSpawn.m_CanSpawn = false;
            m_DickBase.SetActive(true);
            return;
        }
        else
        {
           return;
        }
            
    }

    private IEnumerator TimerGame(){
        while (timer>0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            uIManager.UpdateTimer(timer);
            
        }

    }


}
