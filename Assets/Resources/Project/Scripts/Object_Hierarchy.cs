using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Object_Hierarchy : MonoBehaviour {

    void Start(){
        //접시에 닿기 전까지는 비활성화 상태
        this.enabled = false;
    }

    void Update(){
        //부모가 있다면 항상 x,z 좌표를 부모와 동기화
        if(transform.parent != null){
            Vector3 parent_position = transform.parent.position;
            transform.position = new Vector3(parent_position.x, transform.position.y, parent_position.z);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(this.enabled){
            if(collision.gameObject.tag != "Ingredient") return; // 재료 오브젝트가 아니면 무시한다.

            if(transform.position.y < collision.transform.position.y) {
                // 속도를 없애고, 둘 중 y좌표가 더 낮은 오브젝트를 기준으로 x좌표와 z좌표를 동기화
                collision.rigidbody.velocity = Vector3.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                //물체의 y좌표만큼 띄우기
                Vector3 p_position = transform.position;
                Vector3 c_position = collision.transform.position;
                c_position.x = p_position.x;
                c_position.y = p_position.y + gameObject.GetComponent<Collider>().bounds.size.y + 0.01f;
                c_position.z = p_position.z;

                transform.position = p_position;
                collision.transform.position = c_position;

                //collision.transform.position = new Vector3(p_position.x, p_position.y + GetComponent<Renderer>().bounds.size.y, p_position.z);
                //두 물체의 회전 초기화
            collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // 두 오브젝트는 isKinematic이 되며, 특정 오브젝트에 종속된다.
            Rigidbody rb = GetComponent<Rigidbody>();
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRb != null) otherRb.isKinematic = true;
            //경고창 삭제용
            collision.gameObject.GetComponent<XRGrabInteractable>().throwOnDetach = false;
            //위에 물건 잡히는거 방지하기
            collision.gameObject.GetComponent<XRGrabInteractable>().enabled = false;

            collision.gameObject.transform.parent = transform;
            rb.isKinematic = false;
            }
        }
    }
}
