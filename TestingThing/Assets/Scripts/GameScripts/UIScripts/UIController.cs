using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Button turret1;
    public Button turret2;
    public Text turretInfoText;

    public GameObject turret_1;
    public GameObject turret_2;

    public int cost1 = 5;
    public int cost2 = 10;

    public GameObject currentTurret;

    public int money = 50;

    public Text moneyText;

    private void Start()
    {
        moneyText.text = "Money: " + money;
    }

    public void Turret1Selected()
    {
        if(currentTurret == turret_1)
        {
            currentTurret = null;
            turretInfoText.text = "Nothing selected";
        }
        else
        {
            currentTurret = turret_1;
            turretInfoText.text = "Turret 1 selected";
        }
        
    }

    public void Turret2Selected()
    {
        if (currentTurret == turret_2)
        {
            currentTurret = null;
            turretInfoText.text = "Nothing selected";
        }
        else
        {
            currentTurret = turret_2;
            turretInfoText.text = "Turret 2 selected";
        }

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    public bool BuyTurret()
    {
        if(currentTurret != null)
        {
            if(currentTurret == turret_1)
            {
                if(money >= cost1)
                {
                    money -= cost1;
                    moneyText.text = "Money: " + money;
                    return true;
                }
            }else if (currentTurret == turret_2)
            {
                if(money >= cost2)
                {
                    money -= cost2;
                    moneyText.text = "Money: " + money;
                    return true;
                }
            }
        }

        return false;
    }

}
