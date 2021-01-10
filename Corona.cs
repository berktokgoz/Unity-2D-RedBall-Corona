using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public int saglik, maxSaglik;
    public float mesafe, hazirlanmaMesafe, atesMesafe;
    public float mermiHizi, mermiZamanlayicisi;
    public bool hazir = false;

    public float mermiSikligi;
    private Animator anim;
    public Transform hedef;
    public GameObject mermi;
    public Transform namluSol, namluSag;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        saglik = maxSaglik;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Hazir", hazir);
        mesafeHesapla();
    }
    void mesafeHesapla()
    {
        mesafe = Vector3.Distance(transform.position, hedef.transform.position);
        if(mesafe < hazirlanmaMesafe)
        {
            hazir = true;
        }
        else
        {
            hazir = false;
        }

    }

    public void AtesEt(bool sagaAtesEt)
    {
        mermiZamanlayicisi += Time.deltaTime;

        if(mermiZamanlayicisi >= mermiSikligi)
        {
            Vector2 mermiYonu = hedef.transform.position - transform.position;
            mermiYonu.Normalize();

            if(sagaAtesEt)
            {
                GameObject mermiKopyasi;
                mermiKopyasi = Instantiate(mermi, namluSag.transform.position, namluSag.transform.rotation);
                mermiKopyasi.GetComponent<Rigidbody2D>().velocity = mermiYonu * mermiHizi;
                mermiZamanlayicisi=0;
             }

            if(!sagaAtesEt)
            {
                GameObject mermiKopyasi;
                mermiKopyasi = Instantiate(mermi, namluSag.transform.position, namluSag.transform.rotation);
                mermiKopyasi.GetComponent<Rigidbody2D>().velocity = mermiYonu * mermiHizi;
                mermiZamanlayicisi = 0;
            }

        }
    }



}
