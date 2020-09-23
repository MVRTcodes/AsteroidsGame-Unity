using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ColliderNaveInicial : MonoBehaviour
{
    public GameObject explosionFX;
    private Rigidbody rb;

    public float TBonificacion;

    private int rnd;

    public GameObject LuzBon;

    public Text Score;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        GameObject GMScore1 = GameObject.Find("TextScore");
        Score = GMScore1.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision) {
            
        if(collision.gameObject.name.Equals("ColUTUM2")){
            
            GameObject o = GameObject.Instantiate(explosionFX, transform.position, transform.rotation) as GameObject;
            o.SetActive(true);
            GameObject.Destroy(o,3f); 
            //Destroy(collision.gameObject);
            
            
            StartCoroutine(Final());
            //gameObject.SetActive(false);
            //SceneManager.LoadScene(3);


        }
         if (collision.gameObject.name.Equals("Bonificador1(Clone)")){
            
            Destroy(collision.gameObject);
            rnd = Random.Range(0,3);
            if(rnd == 0) StartCoroutine(FXBonificacion());
            if(rnd == 1) StartCoroutine(FXBonificacion2());
            if(rnd == 2) StartCoroutine(FXBonificacion3());

        }
        
    
    }

    IEnumerator FXBonificacion(){
        LuzBon.SetActive(true);
        TBonificacion = Time.time + 10;
        rb.mass = 4;
        while(TBonificacion>=Time.time){
            yield return null;
        }
        LuzBon.SetActive(false);
        yield return rb.mass = 8.58f;
        
    }

    IEnumerator FXBonificacion2(){
        LuzBon.SetActive(true);
        TBonificacion = Time.time + 10;
        this.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        while(TBonificacion>=Time.time){
            yield return null;
        }
        LuzBon.SetActive(false);
        yield return this.gameObject.transform.localScale = new Vector3(1,1,1);
        
    }

    IEnumerator FXBonificacion3()
    {
        LuzBon.SetActive(true);
        TBonificacion = Time.time + 10;
        this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        while (TBonificacion >= Time.time)
        {
            yield return null;
        }
        LuzBon.SetActive(false);
        yield return this.gameObject.transform.localScale = new Vector3(1, 1, 1);

    }

    IEnumerator Final()
    {
        GameObject GMScore = GameObject.Find("ScoreGlobal");

        ScoreScript ScoreS = (ScoreScript)GMScore.GetComponent(typeof(ScoreScript));
        ScoreS.setScore(Score.text);
        float Hora = Time.time + 1;
        while (Hora >= Time.time)
        {
            print(Hora + "  " + Time.time);
            yield return null;
        }
        print("Oleeeee");
        SceneManager.LoadScene(3);
        print("Tendria que estar fuera");



    }

}
