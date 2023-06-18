using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ObsticleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> things;
    private float waiting;
    private int index;
    private GameObject player;
    Vector3 spawnPos;
    private float randomSpawnX;
    private float rate = 1;
    private PlayerController playerScript;
    public float interpolationPeriod = 5;
    private float time = 0.1f;
    private float yValue;
    public TextMeshProUGUI scrollingText;
    public TextMeshProUGUI spawnSpeedText;
    
    public GameObject rateTextBox;
    public GameObject speedTextBox;


    
    

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("speedBool") == 1){
            speedTextBox.SetActive(true);
        }
        else{
            speedTextBox.SetActive(false);
        }
        if(PlayerPrefs.GetInt("rateBool") == 1){
            rateTextBox.SetActive(true);
        }
        else{
            rateTextBox.SetActive(false);
        }


        scrollingText.text = "Player speed " + Math.Round(playerScript.scrollingSpeed, 2);
        spawnSpeedText.text = "Spawn rate " + Math.Round(waiting,2);


        time+= Time.deltaTime;
        index = UnityEngine.Random.Range(0,things.Count);
        randomSpawnX = UnityEngine.Random.Range(-3.0f,3.0f);
        if(time >= interpolationPeriod){
            time = time - interpolationPeriod;
            if(playerScript.scrollingSpeed < 13){
            playerScript.scrollingSpeed *= 1.05f;}
            else{
                playerScript.scrollingSpeed = 13;
            }

            if(rate > 0.4f){
            rate -= 0.01f;}
            else{
                rate = 0.4f;
            }
        }
        
        
        
    }

    private void SpawnNext(){
        
        if(things[index].name == "Ramp"){
            yValue = 3.5f -1.32f;
            spawnPos = new Vector3(randomSpawnX, yValue, player.transform.position.z + 100);
        }
        else if(things[index].name == "RepairIcon"){
            yValue = 4;
            spawnPos = new Vector3(randomSpawnX, yValue, player.transform.position.z + 100);
        }
        else if(things[index].name == "Wheel"){
            yValue = 3.5f;
            spawnPos = new Vector3(randomSpawnX, yValue, player.transform.position.z + 100);
        }
        else{
            yValue = 3.5f;

            spawnPos = new Vector3(UnityEngine.Random.Range(0,3), yValue, player.transform.position.z + 100);
        }

        
            
        Instantiate(things[index], spawnPos, things[index].transform.rotation);
        
        if(!playerScript.gameOver){
        StartCoroutine(Waiting());}


        


    }
    IEnumerator Waiting(){
        waiting = UnityEngine.Random.Range(0.5f * rate,1.5f * rate);
        
        
        yield return new WaitForSeconds(waiting);
        
        SpawnNext();
    }

    public void changeRate(){
        if(PlayerPrefs.GetInt("rateBool") == 1){
            PlayerPrefs.SetInt("rateBool",0);
        }
        else{
            PlayerPrefs.SetInt("rateBool",1);
        }
    }

    public void changeSpeed(){
        if(PlayerPrefs.GetInt("speedBool") == 1){
            PlayerPrefs.SetInt("speedBool",0);
        }
        else{
            PlayerPrefs.SetInt("speedBool",1);
        }
    }


    


}
