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
    GameObject soapsPanel;
    GameObject foodsPanel;
    GameObject fondoFood;
    GameObject fondoSoaps;
    GameObject soaps;
    GameObject medicine;
    public  GameObject loadingPanel;
    GameObject[] arrayFoods = new GameObject[4];
    public GameObject[] arraySoaps = new GameObject[2];

    int WindowsOpen;
    int footSelec;
    int soapsSelec;
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
        //inventario base
        panelBag = GameObject.Find("PanelBag");
        combatButton = GameObject.Find("Combat");
        bagButton = GameObject.Find("Bag");
        feroxMenu = GameObject.Find("PanelFerox");
        feroxButton = GameObject.Find("Pet");
        optionsButton = GameObject.Find("Options");
        buttons = GameObject.Find("Buttons");
        loadingPanel = GameObject.Find("LoadingPanel");

        //Estadisticas menu
        speedText = GameObject.Find("Speed_Text").GetComponent<Text>();
        hpText = GameObject.Find("Vida_Text").GetComponent<Text>();
        defText = GameObject.Find("Defensa_Text").GetComponent<Text>();
        atkText = GameObject.Find("Ataque_Text").GetComponent<Text>();
        feroxEquip = GameObject.Find("FeroxEquipo");
        feroxStats = GameObject.Find("FeroxStats");
        feroxPedia = GameObject.Find("FeroxPedia");

        //ferox Items
        meats = GameObject.Find("Meats");
        fruts = GameObject.Find("Fruts");
        drinks = GameObject.Find("Drinks");
        sweets = GameObject.Find("Sweets");
        soapsPanel = GameObject.Find("PanelSoaps");
        foodsPanel = GameObject.Find("PanelFoods");
        fondoFood = GameObject.Find("FondoFoods");
        fondoSoaps = GameObject.Find("FondoSoaps");
        soaps = GameObject.Find("Soapss");
        medicine = GameObject.Find("Medicine");
        
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
        soapsPanel.SetActive(false);
        foodsPanel.SetActive(false);
        atkText.text = player.GetAtk.ToString();
        speedText.text = player.GetSpeed.ToString();
        defText.text = player.GetDef.ToString();
        hpText.text = player.GetHp.ToString();
        arrayFeroxMenu[0] = feroxStats;
        arrayFeroxMenu[1] = feroxEquip;
        arrayFeroxMenu[2] = feroxPedia;
        arrayFoods[0] = meats;
        arrayFoods[1] = fruts;
        arrayFoods[2] = drinks;
        arrayFoods[3] = sweets;
        arraySoaps[0] = soaps;
        arraySoaps[1] = medicine;
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
        foodsPanel.SetActive(true);
        ChageTipeFood(0);
    }

    public void Soaps()
    {
        openbag = false;
        panelBag.SetActive(openbag);
        combatButton.SetActive(false);
        bagButton.SetActive(false);
        soapsPanel.SetActive(true);
        ChageTipeSoaps(1);
    }

    public void ChageTipeSoaps(int tipes)
    {
        soapsSelec = tipes;
        for (int i = 0; i < arraySoaps.Length; i++)
        {
            arraySoaps[i].SetActive(false);
        }
        arraySoaps[soapsSelec].SetActive(true);
       fondoSoaps.GetComponent<ScrollRect>().content = arraySoaps[soapsSelec].GetComponent<RectTransform>();
    }
    

    public void Eat()
    {
        combatButton.SetActive(true);
        bagButton.SetActive(true);
        foodsPanel.SetActive(false);
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
        healthCur = player.GetHealt;
        energyCur = player.GetEnergy;
        happinessCur = player.GetHappines;
        dirtCur = player.Getdirt;
        hungryCur = player.GetHungry;
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
