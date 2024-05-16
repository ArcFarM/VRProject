/*using UnityEngine;
using System.Collections.Generic;

public class Show_Menu : MonoBehaviour
{
    public GameObject board;
    public GameObject life;
    private List<string> guestList;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guest")
        {
            guestList = other.gameObject.GetComponent<Guest>().GetList();

            for (int i = 0; i < guestList.Count; i++)
            {
                GameObject ingredient = GameObject.FindWithTag(guestList[i]);
                GameObject newIngredient = Instantiate(ingredient, board.transform.position + new Vector3(i % 2, i / 2, 0), Quaternion.identity);
                newIngredient.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ingredient")
        {
            List<string> plateList = collision.gameObject.GetComponent<Plate>().GetList();

            if (plateList.Count != guestList.Count)
            {
                life.GetComponent<Life>().DecreaseLife();
                return;
            }

            for (int i = 0; i < plateList.Count; i++)
            {
                if (plateList[i] != guestList[i])
                {
                    life.GetComponent<Life>().DecreaseLife();
                    return;
                }
            }

            // life.GetComponent<Life>().Up_Score(guestList);

            foreach (Transform child in board.transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Guest>().Go_Outside();
        }
    }
}*/