using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Object_Hierarchy : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag != "Ingredient") return; // 재료 오브젝트가 아니면 무시한다.

        if(transform.position.y < collision.transform.position.y) {
            // 둘 중 y좌표가 더 낮은 오브젝트를 기준으로 x좌표와 z좌표를 동기화
            collision.rigidbody.velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //물체의 collider의 y좌표만큼 띄우기
            Vector3 p_position = transform.position;
            collision.transform.position = new Vector3(p_position.x, p_position.y + GetComponent<Renderer>().bounds.size.y, p_position.z);
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
        }
    }
}
