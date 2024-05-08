using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Theme.Primitives;

public class Move_Guest : MonoBehaviour
{
    public Transform StartingPos;       //�մ��� ��� ����
    public Vector3 DoorstepPos;          //�� ���� ���� ����
    public float MoveSpeed = 3.0f;      //�̵� �ӵ�
    public float RotationSpeed = 45.0f;  //�� �� ���� �� ȸ�� �ӵ�
    public float RotationAngle = -90.0f;  //�� �� ���� �� ȸ�� ����
    private Vector3 CounterPos = new Vector3(4.25f, 1.9f, 32.274f);       //ī���� ��ġ

    public bool isMoving = true;       //�մ��� �̵� ������ Ȯ���ϴ� flag ����
    void Start()
    {
        StartingPos = transform;
        DoorstepPos = transform.position;
        DoorstepPos.x = 5.6f;           //���� ���� ��ǥ ����
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, DoorstepPos, MoveSpeed * Time.deltaTime);       //���ձ��� �մ� �̵�
            if (transform.position == DoorstepPos)       // �� �� ���� �� ���� ī���ͷ� ���� �ڷ�ƾ ����
            {
                isMoving = false;
                StartCoroutine(Rotate());
            }
            if(transform.position.x == CounterPos.x)        // ī���� �տ� ���� �� �ڷ�ƾ ����
            {
                isMoving = false;
                StopCoroutine(Rotate());
            }
        }
    }

    IEnumerator Rotate()
    {
        Quaternion targetRotation = Quaternion.Euler(0, RotationAngle, 0);      //���� �� ȸ�� ���� ���� 
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);       //ȸ��
            yield return null;      // �� �� ������ ���
        }

        yield return new WaitForSeconds(0.25f);     //0.25�� �� �մ� �̵�
        DoorstepPos = CounterPos;        //ī���ͷ� �̵�
        isMoving = true;
        Debug.Log(DoorstepPos);
        Debug.Log(isMoving);
        yield break;
    }
}
