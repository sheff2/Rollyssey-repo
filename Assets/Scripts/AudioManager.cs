using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public static AudioManager instance;

    // Start is called before the first frame update
    private void Awake() {
        if(instance == null){
        instance = this;
        DontDestroyOnLoad(gameObject);}
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
