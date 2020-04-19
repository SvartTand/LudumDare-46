﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {

    public float maxHp;
    public bool hpBar;

    private float currentHp;
    public Slider bar;
    public Text hpText;

	// Use this for initialization
	void Start () {
        currentHp = maxHp;
        if (hpBar)
        {
            hpText.text = currentHp + "/" + maxHp;
        }
	}
	
	public void TakeDmg(float dmg)
    {
        currentHp = currentHp - dmg;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }

        if (hpBar)
        {
            hpText.text = currentHp + "/" + maxHp;
            bar.value = currentHp / maxHp;
            
        }
        
    }
}