using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnKill : MonoBehaviour
{
    private Oyuncu oyuncu;

    [SerializeField] Transform spawnPoint;

    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            oyuncu.hasarAl(1);
            collision.transform.position = spawnPoint.position;
        }
    }
}
