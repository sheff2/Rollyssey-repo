using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class ScoreCounter : MonoBehaviour
{

    private GameObject player;
    public float score;
    public float coinCount;
    public TextMeshProUGUI scoreText;
    private PlayerController playerC;
    public TextMeshProUGUI coinText;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount = playerC.coinCount;
        score = Mathf.Round(player.transform.position.z);   
        scoreText.text = score + " m";
        coinText.text = coinCount + "";

    }
}
