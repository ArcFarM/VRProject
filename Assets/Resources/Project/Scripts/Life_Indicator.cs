using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Indicator : MonoBehaviour
{
    public int lifeCount;
    static int life_num = 3;
    public GameObject[] light = new GameObject[life_num];

    void Start(){
        lifeCount = life_num;
        Life_Init();
    }

    private void Life_Init(){
        for(int i = 0; i < life_num; i++){
            light[i].SetActive(true);
        }
    }

    public void Set_Life(bool flag){
        //주문이 실패하면 라이프를 차감
        if(!flag){
            light[lifeCount - 1].SetActive(false);
            lifeCount--;
        }
    }
}
