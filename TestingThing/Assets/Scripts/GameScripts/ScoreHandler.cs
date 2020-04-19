using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour {

    public int score;

    public void LoadGameOver(int score)
    {
        this.score = score;
        Object.DontDestroyOnLoad(this);
        SceneManager.LoadScene("GameOverScene");
    }
}
