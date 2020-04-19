using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorController : MonoBehaviour {

    public float spawnrate;
    private float timer;
    public Transform planet;
    public GameObject meteor;
    public float distance = 100;

    private List<Meteor> meteors;

    private int score = 0;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        meteors = new List<Meteor>();
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= spawnrate)
        {
            

            GameObject tempMeteor = Instantiate(meteor, Random.onUnitSphere * distance, transform.rotation, this.transform);
            tempMeteor.GetComponent<Meteor>().Init(planet, this);
            meteors.Add(tempMeteor.GetComponent<Meteor>());
            timer = 0;
        }
	}
    public void Remove(Meteor meteor, bool s)
    {
        meteors.Remove(meteor);
        if (s)
        {
            score++;
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
