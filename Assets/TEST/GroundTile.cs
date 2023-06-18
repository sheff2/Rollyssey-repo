
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    groundspawnertest groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.Find("ObsticleSpawner").GetComponent<groundspawnertest>();
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
        groundSpawner.SpawnTile();
        Destroy(gameObject,2);}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
