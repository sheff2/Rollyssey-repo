using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<GameObject> balls;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI coinAmount;
    
    int index;
    public void Start(){
        
        index = PlayerPrefs.GetInt("ball");
        balls[index].SetActive(true);

    }
    public void Update(){
        highScore.text = "" + PlayerPrefs.GetFloat("highScore");
        coinAmount.text = "" + PlayerPrefs.GetFloat("coins");
    }



    public void PlayGame(){

        PlayerPrefs.SetInt("ball", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame(){
        Application.Quit();
        
    }

    public void fowardButtonClick(){
        if(index == balls.Count-1){
            index = 0;
        }
        else{
            index++;
        }
        for(int i = 0; i < balls.Count; i++){
            if(i == index){
                balls[i].gameObject.SetActive(true);
            }
            else{
                balls[i].gameObject.SetActive(false);
            }
        }

    }

    public void backButtonClick(){
        if(index == 0){
            index = balls.Count-1;
        }
        else{
            index--;
        }
        for(int i = 0; i < balls.Count; i++){
            if(i == index){
                balls[i].gameObject.SetActive(true);
            }
            else{
                balls[i].gameObject.SetActive(false);
            }
        }

    }



}
