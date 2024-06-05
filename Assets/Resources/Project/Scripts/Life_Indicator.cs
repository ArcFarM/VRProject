using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Indicator : MonoBehaviour
{
    GameManager gm;
    int life_num;
    int lifeCount;
    public GameObject[] light;

    void Start(){
        gm = GameManager.pub_ins;
        life_num = gm.life_init;
        lifeCount = gm.life_now;
        Life_Init();
    }

    void Update(){
        lifeCount = gm.life_now;
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
