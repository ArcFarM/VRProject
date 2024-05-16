using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ing_Enum;

public class Make_Order : MonoBehaviour
{
    //난이도 조절을 위한 스테이지 카운터
    //public GameObject stageCounter;
    private int level;
    private List<Ing_List> order = new List<Ing_List>();
    // Start is called before the first frame update
    void Start()
    {
        //level = stageCounter.GetComponent<StageCounter>().level;

        //임시용
        level = 1;
        Add_Ing();
        for(int i = 0; i < order.Count; i++)
        {
            Debug.Log(order[i]);
        }
    }

    void Add_Ing()
    {
        var values = System.Enum.GetValues(typeof(Ing_List));
        int count = UnityEngine.Random.Range(1, 4) + level; // 빵과 빵 사이에는 level + 1 ~ 3개의 재료

        int bunL_num = UnityEngine.Random.Range(0, 5); //밑에 오는 빵은 5종류
        int bunU_num = UnityEngine.Random.Range(5, 10); //위에 오는 빵은 5종류

        //리스트의 맨 처음에는 밑에 오는 빵이 있어야 하고,
        order.Add((Ing_List)bunL_num);

        //빵 사이에 오는 재료들 추가
        for (int i = 0; i < count; i++)
        {
            Ing_List randomIngredient = (Ing_List)values.GetValue(UnityEngine.Random.Range(11, values.Length));
            order.Add(randomIngredient);
        }

        //리스트의 맨 마지막에는 위에 오는 빵이 있어야 한다
        order.Add((Ing_List)bunU_num);
    }

    public List<Ing_List> getList(){
        return order;
    }
}
