using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100; //speed
    private Rigidbody playerRB; //rigidbody
    private float input;  // horizontal input 
    private float Vinput; // vertical input
    private RoadAdder roadAdder; // script which has a function that adds roads
    private bool isGrounded; // true if player hasnt used jump
    public float jumpSpeed; //jumping force
    public float scrollingSpeed = 2; //default speed no input gets 5 percent faster every 5 seconds in obsticle spawner script
    public GameObject indicator; //ring that spawns when powerup is active
    private float powerUpDuration = 5; // seconds the power up lasts
    private bool hasPowerup = false; //true if power up active
    public bool gameOver = false; // game over t/f
    private GameManager gameScript; //refrence to game manager script
    public int coinCount; // how many coins during the game 
    private float powerUpTime; //countdown time for powerup
    public GameObject powerUpImage;  //red bar that indicates time left on powerup

    // sounds 
    public AudioClip ChChing; 
    public AudioClip poweUpCollect; 
    public AudioClip tirePop;
    public AudioClip crashDeath;
    public AudioClip jumpSound;
   private AudioSource audioSource;
   //particle effects
   public ParticleSystem moneyBurst;
   public ParticleSystem deathExplosion;
   public ParticleSystem tireExplosion;

//list of balls you can pick
   public List<GameObject> Balls;

    
    

    // Start is called before the first frame update
    void Start()
    {
        //gets all the refrences
        playerRB = GetComponent<Rigidbody>();
        gameScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        Balls[PlayerPrefs.GetInt("ball")].SetActive(true);
        roadAdder = GameObject.Find("ObsticleSpawner").GetComponent<RoadAdder>();

    }

    private void FixedUpdate() {
        //if game not over then the player can move
        if(!gameOver){
        Vector3 horizontalMove = transform.right * input * speed * Time.fixedDeltaTime;
        Vector3 verticalMove = transform.forward * (Vinput+scrollingSpeed) * speed * Time.fixedDeltaTime;

        playerRB.velocity = verticalMove + horizontalMove + new Vector3(0,playerRB.velocity.y,0);}
    }

    // Update is called once per frame
    void Update()
    {
        //size of the powerup image
        powerUpImage.transform.localScale = new Vector3(powerUpTime / (5f/3f),.2f,1);

        //if there is a power up the poweruptime will decrease with time
        //indicator will be set active
        if(hasPowerup){
        powerUpTime -= Time.deltaTime;
        indicator.SetActive(true);
        //no more powerup time no more powerup
        if(powerUpTime < 0)
       {
          powerUpTime = 0;
          hasPowerup = false;
       }
        
        }

        //if no power up time left the indicator is inactive
        else{
            indicator.SetActive(false);
        }
        
        //get imputs from vertical and horizontal axis
        Vinput = Input.GetAxis("Vertical");
        input = Input.GetAxis("Horizontal");

        //if powerup active and they aren't in the air from a jump and they click space then they jump
        //plays a jump noise
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && hasPowerup){
            playerRB.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound);

        }




        
        
    }

    //method runs when the player collideds with a collider
    private void OnCollisionEnter(Collision other) {
    
        isGrounded = true;

        
        //game over. play noise and particle effects
        if(other.gameObject.CompareTag("BadObstacle")){
            playerRB.velocity = new Vector3(0,0,0);
            if(!gameOver){
            gameOver = true;
            audioSource.PlayOneShot(crashDeath);
            Instantiate(deathExplosion,transform.position,moneyBurst.transform.rotation);
            }

            gameScript.GameOverScreen();
        }
        

        
        
}
//method runs when player collides with a trigger
private void OnTriggerEnter(Collider other) {
    //collides with eheel
    if(other.gameObject.CompareTag("WheelCube")){
        //game over stuff happens if there isn't a powerup active
        if(!hasPowerup){
        if(!gameOver){
        audioSource.PlayOneShot(crashDeath);
        gameOver = true;
        Instantiate(deathExplosion,transform.position,moneyBurst.transform.rotation);
        }
        playerRB.velocity = new Vector3(0,0,0);
        gameScript.GameOverScreen();
        }
        //if there is a powerup active then the tire expoldes and destroys
        else{
            Instantiate(tireExplosion,transform.position,moneyBurst.transform.rotation);
            audioSource.PlayOneShot(tirePop);
            Destroy(other.transform.root.gameObject);
        }
    }
    //calls method from road adder to spawn a new road tile
    if(other.gameObject.CompareTag("RoadTrigger")){
    roadAdder.SpawnCube();
    }
    //destroys coin and adds it to the coin count
    if(other.gameObject.CompareTag("Coin")){
            Instantiate(moneyBurst,transform.position,moneyBurst.transform.rotation);
            Destroy(other.gameObject);
            coinCount++;
            audioSource.PlayOneShot(ChChing);
        }
    //gets the powerup    
    if(other.gameObject.CompareTag("Powerup")){
        Destroy(other.gameObject);
        audioSource.PlayOneShot(poweUpCollect);
        //indicator.SetActive(true);
        hasPowerup = true;
        powerUpTime = powerUpDuration;
        }

}
}
