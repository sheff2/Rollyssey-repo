using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerController playerScript;
    public TextMeshProUGUI gameOverText;
    public GameObject firstMenu;
    private ScoreCounter scoreScript;
    private float current;
    private bool wasInvoked;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        scoreScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
    }

    public void GameOverScreen(){
        if(scoreScript.score >= PlayerPrefs.GetFloat("highScore")){
            PlayerPrefs.SetFloat("highScore", scoreScript.score);
        }
        current = PlayerPrefs.GetFloat("coins");
        if(!wasInvoked){
        PlayerPrefs.SetFloat("coins", current+scoreScript.coinCount);
        wasInvoked = true;
        }
        firstMenu.SetActive(true);

        
    }
    
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome(){
        SceneManager.LoadScene(0);
    }

   



}
