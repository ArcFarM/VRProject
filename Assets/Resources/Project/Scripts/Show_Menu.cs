using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Ing_Enum;

public class Show_Menu : MonoBehaviour {
    //메뉴를 보여줄 종합 화면
    public GameObject display;
    //메뉴 구성이 들어갈 자리와 메뉴에 둘어올 수 있는 재료의 최대 개수
    static int menu_num = 10;
    public GameObject[] menu_arr = new GameObject[menu_num];

    //메뉴를 가지고 올 손님과 손님의 리스트
    public GameObject guest;
    public List<Ing_List> menu_list = new List<Ing_List>();

    //메뉴판이 보여줄 손님이 위치할 자리
    public GameObject waypoint;

    //재료 프리팹을 저장할 리스트
    public List<GameObject> ing_list = new List<GameObject>();

    //현재 메뉴를 표시해야 하는 지를 결정하는 플래그
    bool flag = false;

    void Start() {
        // Ing_List 열거형의 각 값에 대해
        foreach (Ing_List ing in Enum.GetValues(typeof(Ing_List)))
        {
            // 해당 이름의 프리팹을 로드
            GameObject prefab = Resources.Load<GameObject>("Project/Prefab/Ingredient/" + ing.ToString());

            // ingredient_list에 추가
            ing_list.Add(prefab);
        }
    }

    void Update(){
        //손님이 자리에 들어오면 메뉴 표시
        if(waypoint.GetComponent<OrderWP_flag>().flag && flag == true) {
            Display_Menu();
            flag = false;
        }
        if(!waypoint.GetComponent<OrderWP_flag>().flag && flag == false) {
            flag = true;
        }
    }

    //메뉴를 화면에 표시하는 메서드
    void Display_Menu(){
        //손님의 메뉴 리스트를 가져옴
        menu_list = guest.GetComponent<Make_Order>().getList();

        //메뉴 리스트를 순회하며 메뉴를 화면에 표시
        for(int i = 0; i < menu_list.Count; i++){
            //열거형에 저장된 재료를 가져오기
            Ing_List ing = (Ing_List)Enum.Parse(typeof(Ing_List), menu_list[i].ToString());
            GameObject ingredient = ing_list[(int)ing];
            Debug.Log(ingredient);
            //메뉴를 화면에 표시
            GameObject newIngredient = Instantiate(ingredient, menu_arr[i].transform.position, Quaternion.identity);
            //메뉴가 움직이지 않도록 설정
            newIngredient.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}