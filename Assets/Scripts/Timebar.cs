using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timebar : MonoBehaviour
{
    public int TargetMoney = 50000;

    [SerializeField] Image white, gray;
    [SerializeField] StockManager stockManager;

    public float time = 120f;

    float TotalTime;
    private void Start()
    {
        TotalTime = time;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        white.fillAmount = time / TotalTime;
        gray.fillAmount = time / TotalTime;

        if (time <= 0)
        {
            if (stockManager.Money > TargetMoney)
            {
                print("You Win!");
            }
            else
            {
                stockManager.Reachup.text = "YOU LOST";
            }
        }
    }


}
