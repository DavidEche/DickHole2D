using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    private int timer = 30;

    private void Start() {
        StartCoroutine(TimerGame());
    }
    private IEnumerator TimerGame(){
        while (timer>1)
        {
            yield return new WaitForSeconds(1);
            timer--;
            uIManager.UpdateTimer(timer);
        }
    }
}
