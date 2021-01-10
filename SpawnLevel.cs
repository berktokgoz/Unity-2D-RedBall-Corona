using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    private Oyuncu oyuncu;



    [SerializeField] Transform spawnPoint2;


    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
   
    }

    public void NextLevelButton()
    {
        oyuncu.BolumSonuPanel.SetActive(false);

        oyuncu.NextLevel();

        oyuncu.transform.position = spawnPoint2.position;

        
    }

}
