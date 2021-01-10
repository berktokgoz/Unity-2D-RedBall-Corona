using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diken : MonoBehaviour
{

    private Oyuncu oyuncu;

    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter2D(Collider2D diger)
    //{
    //    if(diger.CompareTag("Player"))
    //    {
    //      oyuncu.hasarAl(1); 
    //    }

    //}

    void OnCollisionEnter2D(Collision2D diger)
    {
        if (diger.gameObject.tag == "Player")
        {
            oyuncu.hasarAl(1);
        }
    }
 
   
}
