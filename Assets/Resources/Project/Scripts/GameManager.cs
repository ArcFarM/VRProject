using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager prv_ins;
    //public static으로 Getter를 구현
    public static GameManager pub_ins {
        get {
            if(prv_ins == null) {
                //Awake로 할당되었지만 null 점검을 실행
                prv_ins = FindObjectOfType<GameManager>();
            }
            return prv_ins;
        }
    }
    //싱글톤에 포함될 요소들

    //손님의 이동을 위해 필요한 waypoint와 counter 배열
    public List<GameObject> waypoints;
    public List<GameObject> counters;

    //게임의 라이프
    public int life;


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
    }


}
