using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ing_Enum;

public class GameManager : MonoBehaviour
{
    static GameManager prv_ins;
    //public static으로 Getter를 구현
    public static GameManager pub_ins {
        get {
            if(prv_ins == null) {
                //Awake로 할당되었지만 null 점검을 실행
                //만약 존재하지 않는다면 새로 생성해서 자기 자신으로 할당
                GameObject gm = new GameObject("GameManager");
                prv_ins = gm.AddComponent<GameManager>();
                DontDestroyOnLoad(gm);
            }
            return prv_ins;
        }
    }
    //싱글톤에 포함될 요소들

    //손님의 이동을 위해 필요한 waypoint와 counter 배열
    public List<GameObject> waypoints;
    public List<GameObject> counters;

    //게임의 초기 목숨과 현재 목숨
    public int life_init = 3;
    public int life_now = 3;

    //메뉴 표시에 사용할 재료 리스트
    public List<GameObject> ing_list = new List<GameObject>();

    void Awake(){
        //접근을 위한 초기화
        if(prv_ins == null) {
            prv_ins = this;
            //다른 씬을 넘어가도 파괴되지 않도록 설정
            //싱글톤이기 때문에 전역처럼 다뤄져야 함
            DontDestroyOnLoad(gameObject);
        } else {
            //이미 존재하고 있으므로 존재할 이유가 없음, 파괴
            Destroy(gameObject);
        }

        // Ing_List 열거형의 각 값에 대해
        foreach (Ing_List ing in System.Enum.GetValues(typeof(Ing_List)))
        {
            // 해당 이름의 프리팹을 로드
            GameObject prefab = Resources.Load<GameObject>("Project/Prefab/Ingredient/" + ing.ToString());

            // ingredient_list에 추가
            ing_list.Add(prefab);
        }
    }


}
