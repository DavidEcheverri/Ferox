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
    int speed, hp, def, atk;
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
    void HealthUp(int healthUp)
    {
        healthCur = healthCur + healthUp;
        if (healthCur > healthTo)
        {
            healthCur = healthTo;
        }
    }

    public void HungryUp (int hungryUp)
    {
        hungryCur = hungryCur + hungryUp;
        if (hungryCur > hungry)
        {
            hungryCur = hungry;
            
        }
    }

    public void EnergyUp(int energyUp)
    {
        energyCur = energyCur + energyUp;
        if (energyCur > energy)
        {
            energyCur = energy;
        }
        Debug.Log("holi");
    }

//Enviar estadisticas de combate
    public int GetAtk()
    {
        return atk;
    }
    public int GetHp()
    {
        return hp;
    }
    public int GetDef()
    {
        return def;
    }
    public int GetSpeed()
    {
        return speed;
    }

//Enviar estadisticas de barras
    public float GetHealt()
    {
        return healthCur;
    }
    public float GetEnergy()
    {
        return energyCur;
    }
    public float GetHungry()
    {
        return hungryCur;
    }
    public float GetHappines()
    {
        return happinessCur;
    }
    public float Getdirt()
    {
        return dirtCur;
    }
}
