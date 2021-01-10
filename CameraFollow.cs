using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector2 kameraHizi;
    public float yumusatX;
    public float yumusatY;
    private GameObject oyuncu;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float xCoor = Mathf.SmoothDamp(transform.position.x, oyuncu.transform.position.x, ref kameraHizi.x, yumusatX);
        float yCoor = Mathf.SmoothDamp(transform.position.y, oyuncu.transform.position.y, ref kameraHizi.y, yumusatY);
        transform.position = new Vector3(xCoor, yCoor, transform.position.z);
        if (!Oyuncu.kameradusurucu && !Oyuncu.kamerayukseltici && !Oyuncu.kamerayukseltici2)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y), transform.position.z);
        }
        else if(Oyuncu.kameradusurucu)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, -27, maxCamPos.y), transform.position.z);
        }
        else if (Oyuncu.kamerayukseltici)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, 15, maxCamPos.y), transform.position.z);
        }
        else if (Oyuncu.kamerayukseltici2)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, 60, maxCamPos.y), transform.position.z);
        }


    }
}
