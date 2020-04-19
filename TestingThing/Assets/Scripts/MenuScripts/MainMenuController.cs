using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


    public Planet planet;
    public Planet moon;
    public Planet planet2;

    public Text playText;

    public Vector3 Level2Pos;
    public Vector3 Level1Pos;

    public float speed;

    public float cameraSpeed;

    private Vector3 target;
    private bool moving = false;

    private string level = "GameScene";

    public AudioSource audioSource;

    
	// Use this for initialization
	void Start () {
        target = Level1Pos;
        planet.GeneratePlanet();
        moon.GeneratePlanet();
        planet2.GeneratePlanet();

	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);


            if (Vector3.Distance(transform.position, target) < 1f)
            {
                moving = false;
            }
        }
        
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene(level);
    }

    public void LeftPressed()
    {
        audioSource.Play();
        playText.text = "Play, Easy";
        target = Level1Pos;
        moving = true;
        level = "GameScene";
    }

    public void RightPressed()
    {
        audioSource.Play();
        playText.text = "Play, Insane";
        target = Level2Pos;
        moving = true;
        level = "Insane";
    }


}
