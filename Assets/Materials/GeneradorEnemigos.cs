using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;

    public float SpawnDelay = 10;

    private float NextTimeSpawn;
    public GameObject LuzPrincipal;
    private Light IlumacionEnemigo;
    void Start()
    {
        //NextTimeSpawn = 10;
        IlumacionEnemigo = LuzPrincipal.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PuedeHacerSpawn()){
            Spawn();
            
        }
        StartCoroutine(GoRed());
    }

    private void Spawn(){
        
        NextTimeSpawn = Time.time + SpawnDelay;
        GameObject enm = GameObject.Instantiate(EnemyPrefab,transform.position,transform.rotation) as GameObject;
        
        enm.SetActive(true);
        
    }

    private bool PuedeHacerSpawn(){
        return Time.time >= NextTimeSpawn;
    }

    IEnumerator GoRed()
     {
         while(GameObject.Find("EnemyEje(Clone)")!=null)
         {
            
            if(IlumacionEnemigo.color != Color.red){
                IlumacionEnemigo.intensity = 2;
                IlumacionEnemigo.color = Color.red;
            }
            yield return null;
        }
        IlumacionEnemigo.intensity = 0.53f;
        IlumacionEnemigo.color = Color.white;
        
     
     }
}
