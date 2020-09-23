using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GeneradorAsteroids : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] AsteroidPrefab = new GameObject[3];

    public float SpawnDelay = 10;

    private float NextTimeSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PuedeHacerSpawn()){
            Spawn();
        }
    }

    private void Spawn(){
        
        int rndast = Random.Range(0,2);
        NextTimeSpawn = Time.time + SpawnDelay;
        GameObject ast = GameObject.Instantiate(AsteroidPrefab[rndast],transform.position,transform.rotation) as GameObject;
        ast.SetActive(true);
    }

    private bool PuedeHacerSpawn(){
        return Time.time >= NextTimeSpawn;
    }
}
