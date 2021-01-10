using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesAraligi : MonoBehaviour
{
    public bool sagAtesAraligi = false;
    private Corona corona;
    // Start is called before the first frame update
    void Start()
    {
        corona = gameObject.GetComponentInParent<Corona>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D diger)
    {
        if(diger.CompareTag("Player"))
        {
            if(sagAtesAraligi)
            {
                corona.AtesEt(true);
            }
            else
            {
                corona.AtesEt(false);
            }
        }
        
    }



}
