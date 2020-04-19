using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public Text scoreText;
    
	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHandler>().score;

    }
	
	public void MenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
