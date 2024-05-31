using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest_Loading : MonoBehaviour
{
    public GameObject guest_spawnpoint;
    //새로 생성할 손님에게 넘겨줄 정보를 저장할 참조용 손님
    public GameObject guest_refer;

    //기본 스폰을 위한 코루틴과 스폰 시간간
    IEnumerator spawn_coroutine;
    float spawn_time = 60.0f;

    //게임 실행 후 최초 대기 시간
    float initial_wait_time = 15.0f;

    void Start(){
        spawn_coroutine = Guest_Spawn();
    }

    void Update(){
        StartCoroutine(spawn_coroutine);
    }

    IEnumerator Guest_Spawn(){
        //최초 대기 시간이 지난 후 손님 스폰
        yield return new WaitForSeconds(initial_wait_time);
        GameObject guest = Instantiate(guest_spawnpoint, transform.position, transform.rotation);
        yield return new WaitForSeconds(spawn_time);
    }

    void Get_Guest_Data(GameObject guest_receiver){
        //guest_refer에 저장된 정보를 동기화
    }

}
