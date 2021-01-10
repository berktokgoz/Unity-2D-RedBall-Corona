using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject BolumSonuPanel;

    public float hiz = 30f;
    public float ziplamaGucu = 200f;
    public float maxHix = 100f;
    public bool havada;
    public bool ikiliziplama;
    public bool rightMove;
    public bool leftMove;
    public static bool bolumSonuMu;
    public static bool nextLevel=false;
    public bool kameradusur;
    public bool kamerayukselt;
    public bool kamerayukselt2;
    public static bool kameradusurucu;
    public static bool kamerayukseltici;
    public static bool kamerayukseltici2;
    public static int halka;
    public static int elmas;
    public Image yildiz1;
    public Image yildiz2;
    public Image yildiz3;
    public Image yildiz4;
    public Image yildiz5;
    public int toplampuan;
    public Text BsElmas;
    public Text BsHalka;
    public static int saglik;
    public bool ziplayamamabolgesi;



    // Start is called before the first frame update
    void Start()
    {

        kameradusurucu = false;
        saglik = 3;

        rb2d = gameObject.GetComponent<Rigidbody2D>();

        //animasyon icin
        anim = gameObject.GetComponent<Animator>();



    }


    // Update is called once per frame
    void Update()
    {

        //animasyon icin
        anim.SetFloat("hiz", Mathf.Abs(rb2d.velocity.x));


        //UI Sag Sol tuslari
        if (rightMove)
        {
            rb2d.AddForce(Vector2.right * hiz * 1);
        }
        if(leftMove)
        {
            rb2d.AddForce(Vector2.right * -hiz * 1);
        }

        if (rb2d.velocity.x > maxHix)
        {
            rb2d.velocity = new Vector2(maxHix, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxHix)
        {
            rb2d.velocity = new Vector2(-maxHix, rb2d.velocity.y);
        }

        //objenin spriteını sağa sola dondurmek icin
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("havada", havada);

        //Space ile zıplama
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if(!havada)
        //    {
        //        rb2d.AddForce(Vector2.up * ziplamaGucu);
        //        ikiliziplama = true;
        //    }
        //    else
        //    {
        //        if(ikiliziplama)
        //        {
        //            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        //            rb2d.AddForce(Vector2.up * ziplamaGucu / 1.5f);
        //            ikiliziplama = false;
        //        }
        //    }

        //}

        kamerakontrol();


    }


   public void sag(int button)
    {
        if(button==0)
        {
            rightMove = false;
        }
        if(button==1)
        {
            rightMove = true;
        }

        transform.localScale = new Vector3(1, 1, 1);
    }

   public void sol(int button)
    {
        if (button == 0)
        {
            leftMove = false;
        }
        if (button == 1)
        {
            leftMove = true;
        }
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void yukari ()
    {
        if(!ziplayamamabolgesi)
        {
            if (!havada)
            {
                rb2d.AddForce(Vector2.up * ziplamaGucu);
                ikiliziplama = true;
            }
            else
            {
                if (ikiliziplama)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * ziplamaGucu / 1.5f);
                    ikiliziplama = false;
                }
            }
        }
       
    }



    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * hiz * h);

        if(rb2d.velocity.x > maxHix)
        {
            rb2d.velocity = new Vector2(maxHix, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxHix)
        {
            rb2d.velocity = new Vector2(-maxHix, rb2d.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Finish")
        {
            bolumSonuMu = true;
            BolumSonuPanel.SetActive(true);
            toplampuan = elmas + halka;
       
            if (Oyun.level == 1)
            {
                BsElmas.text = "3/" + elmas.ToString();
                BsHalka.text = "3/" + halka.ToString();
                  
                if (toplampuan < 2)
                {
                    yildiz1.enabled = false;
                    yildiz2.enabled = false;
                    yildiz3.enabled = false;
                    yildiz4.enabled = false;
                    yildiz5.enabled = false;
                }
                else if (toplampuan >= 2 && toplampuan < 4)
                {
                    yildiz1.enabled = false;
                    yildiz3.enabled = false;
                    yildiz4.enabled = false;
                    yildiz5.enabled = false;
                }
                else if(toplampuan >= 4 && toplampuan < 6)
                {
                    yildiz1.enabled = false;
                    yildiz2.enabled = false;
                    yildiz3.enabled = false;
                }
                else
                {
                    yildiz4.enabled = false;
                    yildiz5.enabled = false;
                }
              

            }

        }


        else if (collision.tag == "halka")
        {
            Destroy(collision.gameObject);
            halka++;
        }

        else if (collision.gameObject.tag == "elmas")
        {
            Destroy(collision.gameObject);
            elmas++;
        }

        else if (collision.tag == "kameradusurmenoktasi")
        {
            kameradusur = true;
            kamerayukselt = false;
            kamerayukselt2 = false;

        }

        else if (collision.tag == "kamerayukselt")
        {
            kameradusur = false;
            kamerayukselt2 = false;
            kamerayukselt = true;

        }

        else if (collision.tag == "kamerayukselt2")
        {
            kameradusur = false;
            kamerayukselt = false;
            kamerayukselt2 = true;

        }




    }



    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Untagged")
    //    {
    //        havada = false;
    //    }

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Untagged")
    //    {
    //        havada = true;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yer")
        {
            havada = false;
        }

        if (collision.gameObject.tag == "ziplayamama")
        {
            havada = false;
            ziplayamamabolgesi = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yer")
        {
            havada = false;
        }
        if (collision.gameObject.tag == "ziplayamama")
        {
            havada = false;
            ziplayamamabolgesi = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yer")
        {
            havada = true;
        }
        if (collision.gameObject.tag == "ziplayamama")
        {
            havada = true;
            ziplayamamabolgesi = false;
        }
    }


    public void kamerakontrol()
    {
        kameradusurucu = kameradusur;
        kamerayukseltici = kamerayukselt;
        kamerayukseltici2 = kamerayukselt2;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "elmas")
    //    {
    //        Destroy(collision.gameObject);
    //        elmas++;
    //    }
    //}

    public void hasarAl(int hasar)
    {
        saglik -= hasar;
    }

    public void NextLevel()
    {
        bolumSonuMu = false;
        nextLevel = true;
     
    }

    //void SahteSurtunme()
    //{
    //    Vector3 hizDusurVek = rb2d.velocity;
    //    hizDusurVek.z = 0f;
    //    hizDusurVek.y = rb2d.velocity.y;
    //    hizDusurVek.x = hizDusurVek.x = 0.8f;
    //    rb2d.velocity = hizDusurVek;
    //}

}
