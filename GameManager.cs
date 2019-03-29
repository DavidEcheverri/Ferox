using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    Player player;
    UIManagerMain uiManagerMain;

    //Control de Tiempo
    public string url = "http://feroxhora.000webhostapp.com/TimeGame.php";
    DateTime timeCur;
    DateTime lastConnection;
    TimeSpan differenceStart;

    //Barras Var

    float healthCur = 500;
    float happinessCur = 20;
    float hungryCur = 100;
    float energyCur = 50;
    float dirtCur = 50;
    bool sick = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManagerMain= GameObject.Find("UIManagerMain").GetComponent<UIManagerMain>();
    }
  

    void Start()
    {
        //using (WWW www = new WWW(url))
        //{
        //    yield return www;
        //    timeCur = Convert.ToDateTime(www.text);
        //    Debug.Log(timeCur);
        //}
        //StartCoroutine(TimeServer());

        timeCur = DateTime.Now;

        PlayerPrefs.SetString("LastConnect", "03/26/2019 16:00:00");

        if (PlayerPrefs.HasKey("LastConnect"))
        {
            lastConnection = Convert.ToDateTime(PlayerPrefs.GetString("LastConnect"));
        }
        else
        {
            lastConnection = DateTime.Now;
        }

        differenceStart = timeCur - lastConnection;

        StatsUpdate();

        player.StatsUpdate(healthCur, happinessCur, hungryCur, energyCur, dirtCur);

        uiManagerMain.BarsUpdate();
        Debug.Log(DateTime.Now);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void StatsUpdate()
    {
        //BARRA DE VIDA
        healthCur = healthCur - (float)(differenceStart.TotalMinutes);
        if (healthCur < 0)
        {
            healthCur = 0;
        }

        //BARRA DE FELICIDAD
        if (sick || dirtCur >= 60)
        {
            if (sick && dirtCur >= 60)
            {
                happinessCur = happinessCur - (float)(differenceStart.TotalMinutes);
            }
            else
            {
                happinessCur = happinessCur - (float)(((differenceStart.TotalMinutes) / 3) * 2);
            }
        }
        else
        {
            happinessCur = happinessCur - (float)((differenceStart.TotalMinutes) / 3);
        }
        if (happinessCur < 1)
        {
            happinessCur = 0;
        }

        // BARRA DE HAMBRE
        hungryCur = hungryCur - (float)((differenceStart.TotalMinutes) / 2);
        if (hungryCur < 1)
        {
            hungryCur = 0;
        }

        // BARRA ENERGIA

        energyCur = energyCur + (float)((differenceStart.TotalMinutes) / 5);


        //BARRA SUCIEDAD

        dirtCur = dirtCur + (float)((differenceStart.TotalMinutes) / 5);

    }

    //IEnumerator TimeServer()
    //{
    //    using (WWW www = new WWW(url))
    //    {
    //        yield return www;
    //        timeCur = Convert.ToDateTime(www.text);
    //        Debug.Log(timeCur);
    //    }
    //}
}
