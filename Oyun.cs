using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Oyun : MonoBehaviour
{


    public GameObject StartPanel;
    public GameObject ControlPanel;
    public GameObject Player;
    public GameObject ControlMenuPanel;
    public GameObject GameOverPanel;
    public Text pcElmas;
    public Text pcHalka;
    public Text pcSaglik;
    private int playeBas;
    public static bool bolumSonu;
    public static bool nextlevelmi;
    public static int level;
    private string puancininlevelcisi;

    // Start is called before the first frame update
    void Start()
    {
        playeBas = PlayerPrefs.GetInt("PlayButonu");
     

        if (playeBas == 0)
        {
            StartPanel.SetActive(true);
            Player.SetActive(false);
        }
        else
        {
            ControlPanel.SetActive(true);
            Player.SetActive(true);
            PlayerPrefs.SetInt("PlayButonu", 0);
            if(level == 1)
            {
                pcElmas.text = "3/"+Oyuncu.elmas.ToString();
                pcHalka.text = "3/"+ Oyuncu.halka.ToString();
            }
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        bolumSonu = Oyuncu.bolumSonuMu;
        nextlevelmi = Oyuncu.nextLevel;
        if (bolumSonu)
        {
            ControlPanel.SetActive(false);
        }
        if (nextlevelmi)
        {
            ControlPanel.SetActive(true);
          
        }
        puanci();
    }

    public void PlayButton()
    {
        level = 1;
        Oyuncu.bolumSonuMu = false;
        PlayerPrefs.SetInt("PlayButonu", 1);
        StartPanel.SetActive(false);
        SceneManager.LoadScene(0);
        Oyuncu.elmas = 0;
        Oyuncu.halka = 0;
    }

    public void BolumSonuMenuButon()
    {
       SceneManager.LoadScene(0);
    }

  
    public void PcmRestartButon()
    {
        PlayerPrefs.SetInt("PlayButonu", 1);
        SceneManager.LoadScene(0);
        Oyuncu.elmas = 0;
        Oyuncu.halka = 0;

    }

    public void PcmMenuButonn()
    {
        PlayerPrefs.SetInt("PlayButonu", 0);
        SceneManager.LoadScene(0);
    }

    public void ControlMenuButon()
    {
        ControlMenuPanel.SetActive(true);
    }
    public void ControlMenuExitButon()
    {
        ControlMenuPanel.SetActive(false);
    }
    public void puanci()
    {
        if(Oyuncu.saglik==-1)
        {
            Player.SetActive(false);
            ControlPanel.SetActive(false);
            GameOverPanel.SetActive(true);

        }

        if(level==1)
        {
            puancininlevelcisi = "3/";
        }
        pcElmas.text = puancininlevelcisi + Oyuncu.elmas.ToString();
        pcHalka.text = puancininlevelcisi + Oyuncu.halka.ToString();
        pcSaglik.text = "3/" + Oyuncu.saglik.ToString();

    }
  


}
