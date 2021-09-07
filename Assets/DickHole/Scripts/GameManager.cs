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
    [SerializeField] private GameObject m_PowerUp;

    private Rigidbody2D _BaseRb;
    private int timer = 30;

    private void Start() {
        _BaseRb = m_Base.GetComponent<Rigidbody2D>();
        StartCoroutine(TimerGame());
    }

    private void Update()
    {
        CheckGameOver();

    }

    private void CheckGameOver()
    {
        if (timer == 0)
        {
            _BaseRb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(m_Base, 0.75f);
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
