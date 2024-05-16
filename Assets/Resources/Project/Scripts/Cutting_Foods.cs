using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting_Foods : MonoBehaviour
{
    public GameObject slicedCheese;         //Slice cheese
    public GameObject slicedFish;           //Slice fish

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("CheeseBig"))     //큰 치즈와 부딪히면
        {
            collision.gameObject.SetActive(false);              //큰 치즈 비활성화
            GameObject cheese = Instantiate(slicedCheese, collision.transform.position, Quaternion.identity);       //슬라이스 치즈 생성
        }

        if(collision.gameObject.name == "Anchovy")              //생선과 부딪히면
        {
            collision.gameObject.SetActive(false);              //생선 비활성화
            GameObject fish = Instantiate(slicedFish, collision.transform.position, Quaternion.identity);       //슬라이스 생선 생성
        }
    }
}