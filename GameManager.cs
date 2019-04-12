using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    Player player;
    UIManagerMain uiManagerMain;

    //Control de Tiempo
    string url = "http://feroxhora.000webhostapp.com/TimeGame.php";
    DateTime timeCur;
    DateTime lastConnection;
    DateTime upHeal, upHap, upHun, upDir, upEner;
    TimeSpan differenceStart;
    TimeSpan differenceHeal, differenceHun, differenceEner, differenceHap, differencideDir;
    

    //Relog

    float frameTime;
    int Seg;
    int min;
    int hor;
    int day; 
    int mon;
    int year;
    bool SetTime= false;


    //Barras Var

    float healthCur = 500;
    float happinessCur = 100;
    float hungryCur = 100;
    float energyCur = 0;
    float dirtCur = 0;
    bool sick = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManagerMain= GameObject.Find("UIManagerMain").GetComponent<UIManagerMain>();
    }


    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            if(www.error == null)
            {
                timeCur = Convert.ToDateTime(www.text);
                frameTime = timeCur.Second;
                min = timeCur.Minute;
                hor = timeCur.Hour;
                day = timeCur.Day;
                mon = timeCur.Month;
                year = timeCur.Year;
                upHap = timeCur;
                upHeal = timeCur;
                upEner = timeCur;
                upHun = timeCur;
                upDir = timeCur;
                PlayerPrefs.SetString("LastConnect", "04/08/2019 12:00:00");

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
                yield return null;
                uiManagerMain.loadingPanel.SetActive(false);
                SetTime = true;
            }
            else
            {
                Debug.Log("error");
            }

        }

    }

    // Update is called once per frame
    void Update ()
    {
        if (SetTime) {
            frameTime = frameTime + Time.deltaTime * 1;
            Seg = (int)frameTime;

            if (Seg >= 59)
            {
                frameTime = 0;
                min++;
                if (min >= 59)
                {
                    min = 0;
                    hor++;
                }
            }
            timeCur = Convert.ToDateTime(mon + "/" + day + "/" + year + " " + hor + ":" + min + ":" + Seg);
            differenceHeal = timeCur - upHeal;
            differenceHap = timeCur - upHap;
            differenceEner = timeCur - upEner;
            differenceHun = timeCur - upHun;
            differencideDir = timeCur - upDir;


            if(differenceHeal.TotalSeconds >= 60)
            {
                player.HealthChange(-50);
                uiManagerMain.BarsUpdate();
                upHeal = timeCur;
            }
            if (differenceEner.TotalSeconds >= 60)
            {
                player.EnergyChange(10);
                uiManagerMain.BarsUpdate();
                upEner = timeCur;
            }
            if (differenceHun.TotalSeconds >= 60)
            {
                player.HungryChange(10);
                uiManagerMain.BarsUpdate();
                upHun = timeCur;
            }
            if (differenceHap.TotalSeconds >= 60)
            {
                player.HappinesChange(10);
                uiManagerMain.BarsUpdate();
                upHap = timeCur;
            }
            //if (differencideDir.Seconds >= 60)
            //{
                
            //}

        }
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

}
