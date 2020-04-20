using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Button turret1;
    public Button turret2;
    public Text turretInfoText;

    public Button ManualButton;
    public bool manualFire;

    public GameObject turret_1;
    public GameObject turret_2;

    public int cost1 = 5;
    public int cost2 = 10;

    public GameObject currentTurret;

    public int money = 50;

    public Text moneyText;

    public AudioSource audioSource;

    

    private void Start()
    {
        moneyText.text = "Money: " + money;
    }

    public void ManualSelected()
    {
        audioSource.Play();
        if (manualFire == true)
        {
            currentTurret = null;
            turretInfoText.text = "Nothing selected";
            manualFire = false;
        }
        else
        {
            currentTurret = null;
            turretInfoText.text = "Manual Fire On";
            manualFire = true;
        }
        

    }

    public void Turret1Selected()
    {
        audioSource.Play();
        manualFire = false;
        if (currentTurret == turret_1)
        {
            currentTurret = null;
            turretInfoText.text = "Nothing selected";
        }
        else
        {
            currentTurret = turret_1;
            turretInfoText.text = "AA defence selected";
        }
        
    }

    public void Turret2Selected()
    {
        audioSource.Play();
        manualFire = false;
        if (currentTurret == turret_2)
        {
            currentTurret = null;
            turretInfoText.text = "Nothing selected";
        }
        else
        {
            currentTurret = turret_2;
            turretInfoText.text = "Missile Launcher selected";
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

    

    public bool BuyTurret(Vector3 pos, Transform parent, MeteorController meteorController, Gravity gravity)
    {

        if(currentTurret != null)
        {
            if(currentTurret == turret_1)
            {
                if(money >= cost1)
                {
                    audioSource.Play();
                    money -= cost1;
                    moneyText.text = "Money: " + money;
                    GameObject temp = Instantiate(currentTurret, pos, transform.rotation, parent);

                    temp.GetComponent<Turret>().Init(meteorController, gravity, parent);
                    return true;
                }
            }else if (currentTurret == turret_2)
            {
                if(money >= cost2)
                {

                    audioSource.Play();
                    money -= cost2;
                    moneyText.text = "Money: " + money;
                    GameObject temp = Instantiate(currentTurret, pos, transform.rotation, parent);

                    temp.GetComponent<MissileLauncher>().Init(meteorController, gravity, parent);
                    return true;
                }
            }
        }

        return false;
    }

    public void UpdateMoney()
    {
        moneyText.text = "Money: " + money;
    }

    public void Exit()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHandler>().LoadGameOver(0);
    }

}
