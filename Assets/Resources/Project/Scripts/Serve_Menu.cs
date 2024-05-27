using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ing_Enum;

public class Serve_Menu : MonoBehaviour
{
    // Start is called before the first frame update

    //손님과 주문받는 접시가 맡는 카운터 자리
    public GameObject guest;
    public GameObject counter;

    //손님 받아오기 및 손님 초기화
    public void GetGuest(){
        //null Check
        if(counter.GetComponent<OrderWP_flag>().guest == null) return;
        guest = counter.GetComponent<OrderWP_flag>().guest;
    }
    
    public void NullGuest(){
        //손님이 나갔는 지 확인
        if(counter.GetComponent<OrderWP_flag>().guest != null) return;
        guest = null;
    }

    //접시에서 음식을 전달받았을 때 메뉴와 비교하고 맞다면 그냥 퇴장, 아니라면 라이프를 감소시키고 퇴장
    public bool Check_Menu(GameObject food){
        //코드 단축을 위한 변수 설정
        List<Ing_List> order = guest.GetComponent<Make_Order>().order;
        //우선 제일 위가 되는 부모를 받아와서 비교한다
        GameObject tmp = food;
        int idx = 0;
        if(tmp.gameObject.GetComponent<Ing_Code>().ing == order[idx]){
            //그 후 해당 부모가 자식이 있다면 계속 진행한다)
            while(tmp.gameObject.transform.childCount > 0){
                tmp = tmp.gameObject.transform.GetChild(0).gameObject;
                idx++;
                if(tmp.gameObject.GetComponent<Ing_Code>().ing == order[idx]){
                    continue;
                }
                else return false;
            }   
            return true;
        } //아니면 주문이 잘못된 것이므로 거짓을 반환
        else return false;
    }

    //서빙용 접시에 음식이 올라갔다면 메뉴가 맞는 지 확인
    void OnCollisionEnter(Collision collision){
        //null을 피하기 위한 초기화
        bool result = false;
        if(collision.gameObject.tag == "Ingredient") 
            result = Check_Menu(collision.gameObject);
        //메뉴가 맞다면 손님 퇴장, 메뉴 치우기는 다른 스크립트에서 처리
        if(result){
            Debug.Log("Order Complete");
            guest.GetComponent<Move_Guest_Renewal>().Go_Outside();
        } else {
            //목숨 차감 추가 필요
            Deubg.Log("Order Failed");
            guest.GetComponent<Move_Guest_Renewal>().Go_Outside();
        }
    }  
}
