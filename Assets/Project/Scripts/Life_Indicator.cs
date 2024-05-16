using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Indicator : MonoBehaviour
{
    public GameObject right;
    public GameObject mid;
    public GameObject left;
    public int lifeCount = 3;

    private void Update()
    {
        if(lifeCount == 0)
        {
            left.SetActive(false);
            mid.SetActive(false);
            right.SetActive(false);
            //life가 0이면 게임 종료
        }
        else if(lifeCount == 1)
        {
            left.SetActive(true);
            mid.SetActive(false);
            right.SetActive(false);
        }
        else if(lifeCount == 2)
        {
            left.SetActive(true);
            mid.SetActive(true);
            right.SetActive(false);
        }
        else if(lifeCount == 3)
        {
            left.SetActive(true);
            mid.SetActive(true);
            right.SetActive(true);
        }
    }
}
