using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Hierarchy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
private bool isProcessingCollision = false;

void OnCollisionEnter(Collision collision)
{
    if (!isProcessingCollision && collision.gameObject.tag == "Ingredient")
    {
        StartCoroutine(ProcessCollision(collision));
    }
}

IEnumerator ProcessCollision(Collision collision)
{
    isProcessingCollision = true;
        this.GetComponent<Rigidbody>().isKinematic = true;
    collision.rigidbody.isKinematic = true;

    // 두 오브젝트의 y좌표를 비교
    if (this.transform.position.y < collision.transform.position.y)
    {
        // 이 오브젝트의 y좌표가 더 낮으면, 충돌한 오브젝트의 부모를 이 오브젝트로 설정
        collision.rigidbody.velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.transform.parent = this.transform;
        Vector3 p_position = this.transform.position;
        Vector3 c_position = collision.transform.position;
        collision.transform.position = new Vector3(p_position.x, p_position.y + collision.collider.bounds.extents.y, p_position.z);
    }
    else
    {
        // 충돌한 오브젝트의 y좌표가 더 낮으면, 이 오브젝트의 부모를 충돌한 오브젝트로 설정
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collision.rigidbody.velocity = Vector3.zero;
        this.transform.parent = collision.transform;
        Vector3 p_position = collision.transform.position;
        Vector3 c_position = this.transform.position;
        this.transform.position = new Vector3(p_position.x, p_position.y + this.GetComponent<Collider>().bounds.extents.y, p_position.z);
    }

    // 부착된 두 오브젝트는 하나의 오브젝트인 것 처럼 행동하게 된다.
    // 부착된 두 오브젝트는 하나의 오브젝트인 것 처럼 행동하게 된다.
    FixedJoint fj = this.gameObject.AddComponent<FixedJoint>();
    fj.connectedBody = collision.rigidbody;

        this.GetComponent<Rigidbody>().isKinematic = false;
    collision.rigidbody.isKinematic = false;
    

    yield return new WaitForSeconds(0.5f); // 0.5초 동안 대기

    isProcessingCollision = false;
}
}
