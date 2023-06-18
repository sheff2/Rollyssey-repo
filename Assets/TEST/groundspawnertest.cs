using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundspawnertest : MonoBehaviour
{

    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    int index;
    // Start is called before the first frame update
    void Start()
    {
     SpawnTile();
     SpawnTile(); 
     SpawnTile(); 
     SpawnTile();    
    }
    public void SpawnTile(){
        index = Random.Range(0,9);


        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        temp.transform.GetChild(2).transform.GetChild(index).gameObject.SetActive(true);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }
   
    
}
