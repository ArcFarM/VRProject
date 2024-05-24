using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public class Move_Guest_Renewal : MonoBehaviour
{
    public List<GameObject> waypoints;
    public List<GameObject> counters;
    public float MoveSpeed = 3.0f;
    public float RotationSpeed = 45.0f;
    public float RotationAngle = -90.0f;
    //최종 목적지와 손님 퇴장지점
    private GameObject last_target = null;
    public GameObject guest_out;
    //index
    public int index = 0;

    void Start()
    {
        //카운터 + 대기실 자리 중 빈 자리를 찾기
        Find_Empty();
        //TODO : 빈 자리가 아예 없다면 주문 실패로 판정하고 라이프 차감
        /*if(last_target == null){
            life--;
            Go_Outside();
        }*/
        //경유지에 last target 넣기
        waypoints.Add(last_target);
        StartCoroutine(Move_Customer(waypoints[index]));

    }

    IEnumerator Move_Customer(GameObject waypoint)
    {
        Vector3 wp_position = waypoint.transform.position;
        Vector3 next_waypoint = new Vector3(wp_position.x, transform.position.y, wp_position.z);

        while (Vector3.Distance(transform.position, next_waypoint) > 0.01f)
        {
            //다음 이동 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, next_waypoint, MoveSpeed * Time.deltaTime);
            yield return null;
        }
        //도착을 했다면 잠시 기다렸다가 재귀적 호출
        yield return new WaitForSeconds(1.0f);
        if(Check_Distance(waypoint.transform)){
            if(index < waypoints.Count - 1) index++;
            StartCoroutine(Move_Customer(waypoints[index]));
        }
    }

    //회전 코루틴
    IEnumerator Rotation_Coroutine() {
        Quaternion target = Quaternion.Euler(0, 0, 0);
        while(transform.rotation != target){
            //각도가 같아질 때까지 회전
            transform.rotation = Quaternion.RotateTowards(
                    transform.rotation, target, RotationSpeed * Time.deltaTime);
        }
        yield return null;
    }

    //빈 자리 찾기
    void Find_Empty(){
        for(int i = 0; i < counters.Count; i++){
                    Debug.Log("Finging Empty Space... " + i);
            //빈 카운터 자리 찾기
            if(counters[i].GetComponent<OrderWP_flag>().flag == false){
                last_target = counters[i];
                counters[i].GetComponent<OrderWP_flag>().flag = true;
                return;
            }
        }
    }

    //거리 측정용
    bool Check_Distance(Transform waypoint){
        if(Mathf.Abs(waypoint.position.x - transform.position.x) <= 0.01f 
            && Mathf.Abs(waypoint.position.z - transform.position.z) <= 0.01f)
        return true;
        else return false;
    }

    //Trigger 입장 시 태그 확인 및 회전
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint_Door")){
            StartCoroutine(Rotation_Coroutine());
        }
        //손님의 퇴장 구현
        if(other.CompareTag("Waypoint_Out")){
            gameObject.SetActive(false);
            UnityEngine.Object.Destroy(gameObject);
        }
    }
    
    //손님 퇴장하기
    public void Go_Outside(){
        transform.position = Vector3.MoveTowards(transform.position, guest_out.transform.position
                                                    , MoveSpeed * Time.deltaTime);
    }
}