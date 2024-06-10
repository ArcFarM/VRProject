using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Object_Hierarchy : MonoBehaviour {

    //각각 이 스크립트의 enable, 그랩 상호작용 탐지, 코루틴 제어용
    public bool flag = false;
    XRGrabInteractable grab_inter_flag;
    Coroutine setCoord_flag =   null;

    GameManager gm;
    void Start(){
        //접시에 닿기 전까지는 비활성화 상태
        grab_inter_flag = this.GetComponent<XRGrabInteractable>();
        flag = false;
        gm = GameManager.pub_ins;
    }

    public void flag_switch(int n){
        if(n > 0){
            flag = true;
        } else {
            flag = false;
        }
    }

    void Update(){
        if(setCoord_flag == null){
            setCoord_flag = StartCoroutine(Set_Coord());
        }
        if(flag) {
            grab_inter_flag.enabled = true;
        } else {
            //부모가 있고, 플래그가 꺼져있으면 잡기 비활성화
            if(transform.parent != null)
                grab_inter_flag.enabled = false;
        }
    }

IEnumerator Set_Coord(){
    Debug.Log(this.gameObject.name+"의 좌표 재설정 시작");
    yield return new WaitForSeconds(0.1f);
    //부모가 있는 오브젝트의 좌표를 부모와 맞추기
    if(this.transform.parent != null && this.transform.parent.tag == "Ingredient"){
        Vector3 p_position = transform.parent.position;
        Vector3 c_position = transform.position;
        c_position.x = p_position.x;
        c_position.y = p_position.y + gameObject.GetComponent<Collider>().bounds.size.y + 0.01f;
        c_position.z = p_position.z;
        transform.position = c_position;
        this.transform.rotation = transform.parent.rotation;
    }
    //부모가 자식 위에 올라갔을 경우 좌표를 다시 내리기
    if(this.transform.childCount > this.gameObject.GetComponent<Ing_Code>().init_child){
        Vector3 p_position = transform.position;
        Vector3 c_position = transform.GetChild(0).transform.position;
        p_position.x = c_position.x;
        p_position.y = c_position.y - gameObject.GetComponent<Collider>().bounds.size.y - 0.01f;
        p_position.z = c_position.z;
        transform.position = c_position;
        this.transform.rotation = transform.parent.rotation;
    }
}

private void OnCollisionEnter(Collision collision) {
    if(flag){
        if(collision.gameObject.tag != "Ingredient") return; // 재료 오브젝트가 아니면 무시한다.

        if(transform.position.y < collision.transform.position.y) {
            // 속도를 없애고, 둘 중 y좌표가 더 낮은 오브젝트를 기준으로 x좌표와 z좌표를 동기화
            collision.rigidbody.velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            // 물체의 y좌표만큼 띄우기
            Vector3 p_position = transform.position;
            Vector3 c_position = collision.transform.position;
            c_position.x = p_position.x;
            c_position.y = p_position.y + gameObject.GetComponent<BoxCollider>().bounds.size.y + 0.01f;
            c_position.z = p_position.z;

            transform.position = p_position;
            collision.transform.position = c_position;

            // 두 물체의 회전 초기화
            collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // 두 오브젝트는 isKinematic이 되며, 특정 오브젝트에 종속된다.
            Rigidbody rb = GetComponent<Rigidbody>();
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

            // 계층 구조 설정 전 isKinematic 설정
            if (otherRb != null) otherRb.isKinematic = true;

            // 경고창 삭제용
            collision.gameObject.GetComponent<XRGrabInteractable>().throwOnDetach = false;
            // 위에 물건 잡히는거 방지하기
            collision.gameObject.GetComponent<XRGrabInteractable>().enabled = false;

            // 부모-자식 관계 설정
            collision.gameObject.transform.parent = transform;

            // 계층 구조 설정 후 isKinematic 설정 해제
            rb.isKinematic = false;

            //하나의 부모가 여러 자식 가지는 걸 방지
            if(transform.childCount > transform.gameObject.GetComponent<Ing_Code>().init_child){
                flag_switch(0);
            } else {
                flag_switch(1);
            }
        }
    }
}

}
