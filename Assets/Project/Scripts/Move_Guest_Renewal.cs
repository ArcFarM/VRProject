using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public class Move_Guest_Renewal : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float MoveSpeed = 3.0f;
    public float RotationSpeed = 45.0f;
    public float RotationAngle = -90.0f;
    //최종 목적지지
    private GameObject last_target = null;
    //index
    private int index = 0;

    //회전을 위한 코루틴
    private IEnumerator Do_Rotate;

    void Start()
    {
        //카운터 자리 중 빈 자리를 1 > 2 > 3 우선순위로 탐색하여 목적지 탐색
        Find_Empty_Counter();
        if(last_target == null){
            //모든 카운터 자리가 차있는 경우 대기 공간으로 이동
            Find_Empty_Waiting();
        }
        Do_Rotate = Rotation_Coroutine();
        StartCoroutine(Move_Customer(waypoints[index]));

    }

    IEnumerator Move_Customer(GameObject waypoint)
    {
        if(index < waypoints.Count) index++;
        Vector3 wp_position = waypoint.transform.position;
        Vector3 next_waypoint = new Vector3(wp_position.x, transform.position.y, wp_position.z);

        while (Vector3.Distance(transform.position, next_waypoint) > 0.01f)
        {
            if(waypoint.tag == "Waypoint_Door" && Check_Distance(waypoint.transform)){
                //문 앞에 도착한 경우 회전
                StartCoroutine(Do_Rotate);
            }

            //다음 이동 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, next_waypoint, MoveSpeed * Time.deltaTime);
            yield return null;
        }
        //도착을 했다면 재귀적 호출
        if(Check_Distance(waypoint.transform)){
            //여기서 원하는 빈자리에 도착하도록 유도
            if(waypoint.tag == "Waypoint_Counter"){
                while(waypoints[index].transform != last_target.transform && index < waypoints.Count){
                    index++;
                }
            }
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
            yield return null;
        }
    }

    //빈 자리 찾기
    void Find_Empty_Counter(){
        for(int i = 0; i < waypoints.Count; i++){
        //카운터가 아닌 경유지는 무시하고, 빈 카운터 자리를 찾기
            if(waypoints[i].tag != "Waypoint_Counter") continue;
            if(waypoints[i].GetComponent<OrderWP_Flag>().flag == false){
                last_target = waypoints[i];
                waypoints[i].GetComponent<OrderWP_Flag>().flag = true;
                return;
            }
        }
    }

    void Find_Empty_Waiting(){
        for(int i = 0; i < waypoints.Count; i++){
            //자리가 없는 대기실 공간으로 최종 목적지를 설정
            if(waypoints[i].tag == "Waypoint_Waiting" 
                && waypoints[i].GetComponent<OrderWP_Flag>().flag == false){
                last_target = waypoints[i];
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
}