using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        StartingPos = transform;
        TargetPos = transform.position;
        TargetPos.x = 5.6f;           //좌표를 문 앞 위치로 변경
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);       //���ձ��� �մ� �̵�
            if (transform.position == TargetPos)       // �� �� ���� �� ���� ī���ͷ� ���� �ڷ�ƾ ����
            {
                isMoving = false;
                StartCoroutine(RotateAndMove());
            }
            if(transform.position.x == CounterPos.position.x)        // ī���� �տ� ���� �� �ڷ�ƾ ����
            {
                isMoving = false;
                StopCoroutine(RotateAndMove());
            }
        }
    }

    IEnumerator RotateAndMove()
    {
        Quaternion targetRotation = Quaternion.Euler(0, RotationAngle, 0);      //���� �� ȸ�� ���� ���� 
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);       //ȸ��
            yield return null;      // 다 돌 때까지 대기
        }

        yield return new WaitForSeconds(0.25f);     //0.25 뒤에 다시 출발
        TargetPos = CounterPos.position;        //ī���ͷ� �̵�
        isMoving = true;
        Debug.Log(TargetPos);
        Debug.Log(isMoving);
    }
}
