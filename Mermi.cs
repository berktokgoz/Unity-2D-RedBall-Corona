using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D diger)
    {

        if (diger.isTrigger != true)
        {
            if (diger.CompareTag("Player"))
            {
                diger.GetComponent<Oyuncu>().hasarAl(1);
            }
        }

    }

}
