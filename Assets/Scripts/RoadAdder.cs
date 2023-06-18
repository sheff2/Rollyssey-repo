using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadAdder : MonoBehaviour

{
    public GameObject[] testCubes;
     private List<GameObject> cubesList;
     GameObject lastAddedToList;
     float lastAddedMaxZPos;
     bool gameStart = true;
     void Start()
     {
         cubesList = new List<GameObject>();
         
     }
     void Update(){
        if(gameStart){
          for(int i = 0; i < 13; i ++){
          SpawnCube();}
          gameStart = false;
        }

     }
     
     public void SpawnCube()
     {
         GameObject cubePrefab;
 
         if (cubesList.Count == 0)
         {
             cubePrefab = Instantiate(testCubes[Random.Range(0, testCubes.Length)], new Vector3(0, 0, 0),
                 Quaternion.identity);
             cubesList.Add(cubePrefab);
         }
         else
         {
             lastAddedToList = cubesList[cubesList.Count - 1];
             
             lastAddedMaxZPos =lastAddedMaxZPos + (lastAddedToList.GetComponent<MeshRenderer>().bounds.size.z * 2);// / 2); 
             
             cubePrefab = Instantiate(testCubes[Random.Range(0, testCubes.Length)]);
             lastAddedMaxZPos += cubePrefab.GetComponent<MeshRenderer>().bounds.size.z *2;// /2;
             cubePrefab.transform.position = new Vector3(0f, 0f, lastAddedMaxZPos);
             cubesList.Add(cubePrefab);
         }
     }
 }