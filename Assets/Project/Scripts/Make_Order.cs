using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ing_Enum;

public class Make_Order : MonoBehaviour
{

    List<Ing_List> order = new List<Ing_List>();
    // Start is called before the first frame update
    void Start()
    {
        AddRandomIngredients();
        for(int i = 0; i < order.Count; i++)
        {
            Debug.Log(order[i]);
        }
    }

    void AddRandomIngredients()
    {
        var values = System.Enum.GetValues(typeof(Ing_List));
        int count = UnityEngine.Random.Range(4, 9); // 4 ~ 8

        for (int i = 0; i < count; i++)
        {
            Ing_List randomIngredient = (Ing_List)values.GetValue(UnityEngine.Random.Range(0, values.Length));
            order.Add(randomIngredient);
        }
    }
}
