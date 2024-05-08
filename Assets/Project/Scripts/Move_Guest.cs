using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Theme.Primitives;

public class Move_Guest : MonoBehaviour
{
    public Transform StartingPos;       //손님의 출발 지점
    public Vector3 DoorstepPos;          //문 앞의 도착 지점
    public float MoveSpeed = 3.0f;      //이동 속도
    public float RotationSpeed = 45.0f;  //문 앞 도착 후 회전 속도
    public float RotationAngle = -90.0f;  //문 앞 도착 후 회전 각도
    private Vector3 CounterPos = new Vector3(4.25f, 1.9f, 32.274f);       //카운터 위치

    public bool isMoving = true;       //손님이 이동 중인지 확인하는 flag 변수
    void Start()
    {
        StartingPos = transform;
        DoorstepPos = transform.position;
        DoorstepPos.x = 5.6f;           //도착 지점 좌표 설정
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, DoorstepPos, MoveSpeed * Time.deltaTime);       //문앞까지 손님 이동
            if (transform.position == DoorstepPos)       // 문 앞 도착 시 돌고 카운터로 가는 코루틴 시작
            {
                isMoving = false;
                StartCoroutine(Rotate());
            }
            if(transform.position == CounterPos)        // 카운터 앞에 도착 시 코루틴 중지
            {
                isMoving = false;
                StopCoroutine(Rotate());
            }
        }
    }

    IEnumerator Rotate()
    {
        Quaternion targetRotation = Quaternion.Euler(0, RotationAngle, 0);      //도착 후 회전 각도 설정 
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);       //회전
            yield return null;      // 다 돌 때까지 대기
        }

        yield return new WaitForSeconds(0.25f);     //0.25초 후 손님 이동
        DoorstepPos = CounterPos;        //카운터로 이동
        isMoving = true;
        Debug.Log(DoorstepPos);
        Debug.Log(isMoving);
        yield break;
    }
}
