using System.Collections;
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
	
	public bool TakeDmg(float dmg)
    {
        currentHp = currentHp - dmg;

        if (currentHp <= 0)
        {

            
            return true;
            Destroy(gameObject);
        }

        if (hpBar)
        {
            Camera.main.GetComponent<CameraController>().Shake(0.1f, 0.5f, 2);
            hpText.text = currentHp + "/" + maxHp;
            bar.value = currentHp / maxHp;
            
        }
        return false;
        
    }
}
