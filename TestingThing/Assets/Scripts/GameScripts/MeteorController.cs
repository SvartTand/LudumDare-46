using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour {

    public float spawnrate;
    private float timer;
    public Transform planet;
    public float distance = 100;

    private List<Meteor> meteors;

    private int score = 0;
    public Text scoreText;

    public UIController ui;

    public int waveAmount;
    public int waveTime;
    private int wave = 1;

    public GameObject meteorSmall;
    public GameObject meteor;
    public GameObject meteorBig;
    public GameObject meteorLarge;

    public float meteorSmallAmount = 0.5f;
    public float meteorAmount = 0.3f;
    public float meteorBigAmount = 0.15f;
    public float meteorLargeAmount = 0.05f;


    // Use this for initialization
    void Start () {
        meteors = new List<Meteor>();
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= waveTime)
        {

            for (int i = 0; i < wave*waveAmount; i++)
            {
                float r = Random.value;
                if(r >= meteorSmallAmount)
                {
                    SpawnMeteor(meteorSmall);
                }else if(r >= meteorAmount)
                {
                    SpawnMeteor(meteor);
                }else if(r >= meteorBigAmount)
                {
                    SpawnMeteor(meteorBig);
                }
                else
                {
                    SpawnMeteor(meteorLarge);
                }
            }
            wave++;
            timer = 0;
        }
	}

    private void SpawnMeteor(GameObject type)
    {
        GameObject tempMeteor = Instantiate(type, Random.onUnitSphere * distance, transform.rotation, this.transform);
        tempMeteor.GetComponent<Meteor>().Init(planet, this);
        meteors.Add(tempMeteor.GetComponent<Meteor>());
    }
    public void Add(Meteor m)
    {
        meteors.Add(m);
    }

    public void Remove(Meteor meteor, bool s)
    {
        meteors.Remove(meteor);
        if (s)
        {
            score++;
            ui.money++;
            ui.UpdateMoney();
            UpdateScore();
        }
        

    }

    public Meteor GetRandom()
    {
        if (meteors.Count >= 1)
        {
            return meteors[Random.Range(0, meteors.Count - 1)];
        }
        return null;
    }
    
    public Meteor getClosest(Vector3 position)
    {
        if(meteors.Count > 0)
        {
            float distance = Vector3.Distance(position, meteors[0].transform.position);
            int t = 0;

            for (int i = 1; i < meteors.Count; i++)
            {
                float temp = Vector3.Distance(position, meteors[i].transform.position);
                if (temp < distance)
                {
                    distance = temp;
                    t = i;
                }
            }
            return meteors[t];
        }
        else
        {
            return null;
        }
        
    }

    public void UpdateScore()
    {
        
        scoreText.text = "Score: " + score;
    }
}
