using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill_Meat : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Steak") || collision.gameObject.name.Contains("Bacon"))
            collision.gameObject.GetComponent<Grillable>().collisionTime += Time.deltaTime;     // 충돌 중이면 시간을 더해줌
    }
}