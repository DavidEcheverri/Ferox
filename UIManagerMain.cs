using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMain : MonoBehaviour {
    //MENU 
    GameObject feroxMenu;
    GameObject feroxButton;
    GameObject panelBag;
    GameObject combatButton;
    GameObject bagButton;
    GameObject fondoFood;
    GameObject optionsButton;
    GameObject buttons;
    GameObject feroxEquip;
    GameObject feroxStats;
    GameObject feroxPedia;
    GameObject[] arrayFeroxMenu= new GameObject[3];
    GameObject meats;
    GameObject fruts;
    GameObject drinks;
    GameObject sweets;
    public GameObject[] arrayFoods = new GameObject[4];
    GameObject buttonsFoods;
    int WindowsOpen;
    int footSelec;
    int numFood;
    Text speedText, hpText, defText, atkText;

    Player player;

    //Barras De Mascotas
    float healthTo = 500;
    float healthCur ;
    Image healthBar;

    float happiness = 100;
    float happinessCur ;
    Image happinessBar;

    float hungry = 100;
    float hungryCur ;
    Image hungryBar;

    float dirt = 100;
    float dirtCur ;
    bool sick = false;
    Image dirtBar;

    float energy = 100;
    float energyCur;
    Image energyBar;



    bool openbag = false;

    private void Awake()
    {
        panelBag = GameObject.Find("PanelBag");
        combatButton = GameObject.Find("Combat");
        bagButton = GameObject.Find("Bag");
        fondoFood = GameObject.Find("FondoFoods");
        speedText = GameObject.Find("Speed_Text").GetComponent<Text>();
        hpText = GameObject.Find("Vida_Text").GetComponent<Text>();
        defText = GameObject.Find("Defensa_Text").GetComponent<Text>();
        atkText = GameObject.Find("Ataque_Text").GetComponent<Text>();
        feroxMenu = GameObject.Find("PanelFerox");
        feroxButton = GameObject.Find("Pet");
        optionsButton = GameObject.Find("Options");
        buttons = GameObject.Find("Buttons");
        feroxEquip = GameObject.Find("FeroxEquipo");
        feroxStats = GameObject.Find("FeroxStats");
        feroxPedia = GameObject.Find("FeroxPedia");
        meats = GameObject.Find("Meats");
        fruts = GameObject.Find("Fruts");
        drinks = GameObject.Find("Drinks");
        sweets = GameObject.Find("Sweets");
        buttonsFoods = GameObject.Find("ButtosFoods");
        //BARRAS REFERENCIA 
        healthBar = GameObject.Find("Health_Bar").GetComponent<Image>();
        happinessBar = GameObject.Find("Hapinness_Bar").GetComponent<Image>();
        hungryBar = GameObject.Find("Hungry_Bar").GetComponent<Image>();
        dirtBar = GameObject.Find("Dirt_Bar").GetComponent<Image>();
        energyBar = GameObject.Find("Energy_Bar").GetComponent<Image>();
    }
    void Start()
    {
        panelBag.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
        feroxMenu.SetActive(false);
        fondoFood.SetActive(false);
        buttonsFoods.SetActive(false);
        atkText.text = player.GetAtk().ToString();
        speedText.text = player.GetSpeed().ToString();
        defText.text = player.GetDef().ToString();
        hpText.text = player.GetHp().ToString();
        arrayFeroxMenu[0] = feroxStats;
        arrayFeroxMenu[1] = feroxEquip;
        arrayFeroxMenu[2] = feroxPedia;
        arrayFoods[0] = meats;
        arrayFoods[1] = fruts;
        arrayFoods[2] = drinks;
        arrayFoods[3] = sweets;
    }


    void Update()
    {
    }

    public void Bag()
    {
        openbag = !openbag;

        panelBag.SetActive(openbag);
    }

    public void Foods()
    {
        openbag = false;
        panelBag.SetActive(openbag);
        combatButton.SetActive(false);
        bagButton.SetActive(false);
        fondoFood.SetActive(true);
        buttonsFoods.SetActive(true);
        ChageTipeFood(0);
    }

    public void NumFoodSelec(int chage)
    {
        numFood = numFood + chage;

        if (numFood > 4)
        {
            numFood = 0;
        }
    }

    public void Eat()
    {
        combatButton.SetActive(true);
        bagButton.SetActive(true);
        fondoFood.SetActive(false);
    }

    public void FeroxPanel()
    {
        buttons.SetActive(false);
        feroxMenu.SetActive(true);
        FeroxPanelWindows(0);
    }

    public void FeroxPanelWindows(int PanelSelec)
    {
        WindowsOpen = PanelSelec;
        for(int i= 0; i<arrayFeroxMenu.Length; i++)
        {
            arrayFeroxMenu[i].SetActive(false);
        }
        arrayFeroxMenu[WindowsOpen].SetActive(true);
    }

    public void CloseFeroxPanel()
    {
        buttons.SetActive(true);
        feroxMenu.SetActive(false);
    }

    public void BarsUpdate()
    {
        healthCur = player.GetHealt();
        energyCur = player.GetEnergy();
        happinessCur = player.GetHappines();
        dirtCur = player.Getdirt();
        hungryCur = player.GetHungry();
        energyBar.fillAmount = energyCur / energy;
        healthBar.fillAmount = healthCur / healthTo;
        dirtBar.fillAmount = dirtCur / dirt; 
        hungryBar.fillAmount = hungryCur / hungry;
        happinessBar.fillAmount = happinessCur / happiness;
    }

    public void ChageTipeFood(int tipef)
    {
        footSelec = tipef;
        for(int i = 0; i < arrayFoods.Length; i++)
        {
            arrayFoods[i].SetActive(false);
        }
        arrayFoods[footSelec].SetActive(true);
        fondoFood.GetComponent<ScrollRect>().content = arrayFoods[footSelec].GetComponent<RectTransform>();


    }    
}
