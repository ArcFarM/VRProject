using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Theme.Primitives;

public class Move_Guest : MonoBehaviour
{
    public Transform StartingPos;       //손님 시작 위치
    public Transform CounterPos;        //카운터 앞 위치
    public Vector3 TargetPos;          //움직일 위치
    public float MoveSpeed = 3.0f;      //움직이는 속도
    public float RotationSpeed = 45.0f;  //도는 속도
    public float RotationAngle = -90.0f;  //도는 각도

    public bool isMoving = true;       //움직이는 지 확인하기 위한 flag
    public bool isMoveForward = false;      //앞으로 움직였는지 확인하기 위한 flag
    void Start()
    {
        StartingPos = transform;
        TargetPos = transform.position;
        TargetPos.x = 5.6f;           //좌표를 문 앞 위치로 변경
        //StartCoroutine(PrintCoordinateOfBothObjects());
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
            if (transform.position == TargetPos)       // 목표 지점에 도착했을 경우
            {
                isMoving = false;
                StartCoroutine(RotateAndMove());
            }
            if ((CounterPos.position.x - 0.01f < transform.position.x  && transform.position.x < CounterPos.position.x + 0.01f)
                && (CounterPos.position.z - 0.01f < transform.position.z - 0.01f && transform.position.z < CounterPos.position.z + 0.01f))
            {
                //카운터에 도착했을 경우
                //단순히 CounterPos.position과 같은 걸로 조건을 걸면 좌표가 실수로 설정되어 있기 때문에 ==이 잘 먹히지 않음
                isMoving = false;
                StopCoroutine(RotateAndMove());
                Debug.Log("도착");
            }
        }
    }

    IEnumerator RotateAndMove()
    {
        Quaternion targetRotation = Quaternion.Euler(0, RotationAngle, 0);      //돌 각도 설정
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            yield return null;      // 다 돌 때까지 대기
        }
        if(!isMoveForward)          // 돈 후 앞으로 5만큼 이동 한 후 카운터 위치로 찾아가게 만들기 위해 조건 설정
        {
            Vector3 intermediatePos = transform.position;
            intermediatePos.z += 5f;        // 중간 좌표 설정
            TargetPos = intermediatePos;
            isMoveForward = true;
            isMoving = true;
            yield return new WaitForSeconds(2.0f);         // 앞으로 다 가기 위해 2초 대기
        }
        TargetPos = CounterPos.position;        //목표 지점을 카운터 앞으로 변경
        isMoving = true;
    }

    /*IEnumerator PrintCoordinateOfBothObjects()
    {
        while (true)
        {
            Debug.Log("transform.position.x = " + transform.position.x);
            Debug.Log("CounterPos.position.x = " + CounterPos.position.x);
            Debug.Log("isMoving : " + isMoving);
            yield return new WaitForSeconds(2.0f);
        }
    }*/
}
