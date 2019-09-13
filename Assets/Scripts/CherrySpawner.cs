using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour
{
    public GameObject cherryPreFab;
     
    public float respawnTime = 3.0f;

    private bool dead = false;

    void Start()
    {
        //StartCoroutine(SpawningCherries());
    }

    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(cherryPreFab) as GameObject;
    }

    /*IEnumerator SpawningCherries()
    {
     

    }*/
}
