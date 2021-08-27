using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;
    public void UpdateTimer(int time){
        timerTxt.text = time.ToString();
    }
}
