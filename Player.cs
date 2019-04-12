using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Barras De Mascotas
    float healthTo = 500;
    float healthCur = 500;
    
    float happiness=100;
    float happinessCur=100;  

    float hungry=100;
    float hungryCur=100;
   
    float dirt=100;
    float dirtCur = 0;
    bool sick = false;
    
    float energy=100;
    float energyCur = 0;
    
    //Stats de combate
    int speed, hp, def, atk= 10;
    int maxSpeed, maxHp, maxDef, maxAtk;
    int speedCur, hpCur, defCur, atkCur;

    //Referencias Escena

    UIManagerMain uiManagerMain;

    private void Awake()
    {
        uiManagerMain = GameObject.Find("UIManagerMain").GetComponent<UIManagerMain>();
    }

    void Start ()
    {
    }

    public void StatsUpdate(float _healt,float _happines,float _hungry,float _energy,float _dirt)
    {
        healthCur = _healt;
        happinessCur = _happines;
        hungryCur = _hungry;
        dirtCur = _dirt;
        if (dirtCur > dirt)
        {
            dirtCur = dirt;
        }
        energyCur = _energy;
        if (energyCur > energy)
        {
            energyCur = energy ;
        }
    }
	
	void Update ()
    {
        
    }

    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetString("LastConnect", DateTime.Now.ToString());
    //}
    public void HealthChange(int healthUp)
    {
        healthCur = healthCur + healthUp;
        healthCur = Mathf.Clamp(healthCur, 0, healthTo);
        Debug.Log(healthCur);
    }

    public void HungryChange (int hungryUp)
    {
        hungryCur = hungryCur + hungryUp;
        hungryCur = Mathf.Clamp(hungryCur, 0, hungry);
    }

    public void EnergyChange(int energyUp)
    {
        energyCur = energyCur + energyUp;
        energyCur = Mathf.Clamp(energyCur, 0, energy);
        Debug.Log("holi");
    }

    public void HappinesChange(int Happines)
    {
        happinessCur = happinessCur + Happines;
        happinessCur = Mathf.Clamp(happinessCur, 0, happiness);
    }



//Enviar estadisticas de combate
    public int GetAtk {get{ return atk; } }
    public int GetHp { get { return hp; } }
    public int GetDef { get { return def; } }
    public int GetSpeed { get { return speed; } }

    //Enviar estadisticas de barras
    public float GetHealt { get { return healthCur; } }
    public float GetEnergy { get { return energyCur; } }
    public float GetHungry { get { return hungryCur; } }
    public float GetHappines { get { return happinessCur; } }
    public float Getdirt { get { return dirtCur; } }
}
