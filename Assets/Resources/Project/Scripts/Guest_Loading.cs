using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest_Loading : MonoBehaviour
{
    public GameObject guest_spawnpoint;
    //새로 생성할 손님에게 넘겨줄 정보를 저장할 참조용 손님
    public GameObject guest_refer;
    //생성할 손님 기본 프리팹
    public GameObject guest_prefab;

    //기본 스폰을 위한 코루틴과 스폰 시간, 코루틴 제어 플래그
    IEnumerator spawn_coroutine;
    float spawn_time = 10.0f;
    bool coroutine_flag = true;

    //게임 실행 후 최초 대기 시간
    float initial_wait_time = 5.0f;
    bool initial_flag = true;

    //손님의 레벨 (주문 난이도)
    int difficulty = 1;
    static int max_difficulty = 8;

    void Update(){
        //난이도는 최대 8까지
        if(difficulty > max_difficulty){
            //난이도가 최대치에 도달하면 코루틴 종료 및 게임 클리어 실행
            //return;
        } else {
            //손님 생성 코루틴 실행 및 반복 실행 차단
            if(coroutine_flag) StartCoroutine(Guest_Spawn());
        }

    }

    IEnumerator Guest_Spawn(){
        coroutine_flag = false;
        //최초 대기 시간이 지난 후 손님 스폰
        if(initial_flag){
            yield return new WaitForSeconds(initial_wait_time);
            initial_flag = false;
        }

        //손님을 생성
        GameObject guest = Instantiate(guest_prefab, guest_spawnpoint.transform.position, guest_spawnpoint.transform.rotation);
        //계층 정리를 위해 부모로 생성용 폴더 오브젝트를 지정하고, 정보 전달을 위해 비활성화
        guest.transform.SetParent(this.transform);
        guest.SetActive(false);
        Get_Guest_Data(guest);
        yield return new WaitForSeconds(2.0f);
        guest.SetActive(true);

        difficulty++;
        coroutine_flag = true;
        yield return new WaitForSeconds(spawn_time);
    }

    void Get_Guest_Data(GameObject guest_receiver){
        //guest_refer에 저장된 경유지 정보를 동기화
        guest_receiver.GetComponent<Move_Guest_Renewal>().waypoints = guest_refer.GetComponent<Move_Guest_Renewal>().waypoints;
        guest_receiver.GetComponent<Move_Guest_Renewal>().counters = guest_refer.GetComponent<Move_Guest_Renewal>().counters;
        guest_receiver.GetComponent<Move_Guest_Renewal>().guest_out = guest_refer.GetComponent<Move_Guest_Renewal>().guest_out;
        guest_receiver.GetComponent<Make_Order>().level = difficulty;
    }

}
