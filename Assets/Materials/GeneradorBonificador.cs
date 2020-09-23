using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBonificador : MonoBehaviour
{
    public GameObject BonPrefab;

    public float SpawnDelay = 60;

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

        NextTimeSpawn = Time.time + SpawnDelay;
        if(GameObject.Find("Bonificador1(Clone)")==null){
        GameObject bon = GameObject.Instantiate(BonPrefab,transform.position,transform.rotation) as GameObject;
        bon.SetActive(true);
        }

    }

    private bool PuedeHacerSpawn(){
        return Time.time >= NextTimeSpawn;
    }
}
