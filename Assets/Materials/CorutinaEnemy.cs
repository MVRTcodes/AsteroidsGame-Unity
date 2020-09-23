using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorutinaEnemy : MonoBehaviour
{
    public GameObject Target;
    public float LookDelay = 2;
    public float velocidadmov = 1f;
    public GameObject ExplosionMuerte;
    public GameObject enemydisp;
    private float NextTimeSpawn;
    public Transform ObjetivoEnemigo;

    void Start()
    {
        
        StartCoroutine(RutinaEnemy(Target));
        StartCoroutine(Corutina(ObjetivoEnemigo));
        
    }

    void Update()
    {
        transform.LookAt(Target.transform);
    }

    IEnumerator RutinaEnemy(GameObject target){

        while(target.activeSelf){
            yield return new WaitForSeconds(3f);
            GameObject go = GameObject.Instantiate(enemydisp, transform.position, transform.rotation) as GameObject;
            go.SetActive(true);
			try{
                GameObject.Destroy(go, 3f);
            }catch{
                print("Ya ha sido destruido");
            }
            
            
        }
        print("El objetivo ha muerto.");
    }
    IEnumerator Corutina(Transform target){
        
        Destroy(this.gameObject,12f);
        while(GameObject.Find("EnemyEje(Clone)")==this.gameObject && Vector3.Distance(transform.position, target.position) > 0.05f){
            
            transform.position = Vector3.Lerp(transform.position, target.position, velocidadmov * Time.deltaTime);
            yield return null;
        }
        print("He llegado al final");
        Destroy(this.gameObject,1f);
    }

    public void OnCollisionEnter(Collision collision) {

        print(collision.gameObject.name);
        if(collision.gameObject.name.StartsWith("ColUTUM")){
            print("BOOM!");
            GameObject boomnave = GameObject.Instantiate(ExplosionMuerte,this.transform.position,this.transform.rotation) as GameObject;
            boomnave.SetActive(true);
            GameObject.Destroy(boomnave,2f);
            gameObject.SetActive(false);
            
        }
    }
}
