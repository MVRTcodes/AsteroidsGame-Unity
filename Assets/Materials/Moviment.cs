using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using UnityEngine.SceneManagement;
/**
* Classe que permet moure i rotar un objecte.
* Utilitza atributs púlics per a la edición Unity
* sergi.grau@fje.edu
* 1.0 27.03.2015
*/
public class Moviment : MonoBehaviour {
    public float velocitat = 1.0F;
    public float velocitatRotacio = 100.0F;
    public KeyCode impulse;

    public KeyCode shoot;
    public Rigidbody nave;
    public Transform navedisp;
    public GameObject m_shotPrefab;

    public GameObject ExplosionMuerte;

    public AudioSource FXDisparo;

    public AudioSource FXImpulso;
    
    public bl_Joystick Joystick;
    public Button A;

    public Button B;

    public float SpawnDelay = 1;

    private float NextTimeSpawn;

    public Text Score;

    void Start(){
        GameObject GMScore1 = GameObject.Find("TextScore");
        Score = GMScore1.GetComponent<Text>();
    }
    
    void Update() {
        //float traslacio = Input.GetAxis("Vertical") * velocitat;
        //transform.Rotate(Vector3.up * velocitatRotacio * Time.deltaTime);
        float rotacio = Input.GetAxis("Horizontal") * velocitatRotacio;
        float v = Joystick.Vertical;
        float h = Joystick.Horizontal;
        float rotacio2 = h * velocitatRotacio;
        //traslacio *= Time.deltaTime;
        rotacio2 *= Time.deltaTime;
        rotacio *= Time.deltaTime;
        
        transform.Rotate(0, rotacio, 0);
        transform.Rotate(0, rotacio2, 0);
        /*
        Vector2 tfmtoV2 = new Vector2(transform.position.x,transform.position.y);
        Vector2 JoyV2 = new Vector2(h,v);
        transform.LookAt(tfmtoV2+JoyV2);*/
        if(Input.GetKeyDown(impulse)){
            ImpulseSound();
            //FXImpulso.Play();
        }
        if(Input.GetKey(impulse)){

            ImpulseNave();
            //((Rigidbody)nave).AddForce (transform.forward * velocitat,ForceMode.Impulse);
        }
        
        if (Input.GetKeyDown(shoot))
		{
            ShootLaser();
		}

        

    }
    
    public void OnCollisionEnter(Collision collision) {

        print(collision.gameObject.name);
        if(collision.gameObject.name.StartsWith("Asteroid")){
            print("BOOM!");
            GameObject boomnave = GameObject.Instantiate(ExplosionMuerte,navedisp.position,navedisp.rotation) as GameObject;
            boomnave.SetActive(true);
            GameObject.Destroy(boomnave,3f);
            //gameObject.SetActive(false);
            StartCoroutine(Final());

        }
        else if(collision.gameObject.name.Equals("EnemyEje(Clone)")){
            print("BOOM!2");
            GameObject boomnave = GameObject.Instantiate(ExplosionMuerte,navedisp.position,navedisp.rotation) as GameObject;
            boomnave.SetActive(true);
            GameObject.Destroy(boomnave,3f);
            //gameObject.SetActive(false);
            StartCoroutine(Final());


        }
    }

    public void ImpulseNave(){
        
        ((Rigidbody)nave).AddForce (transform.forward * velocitat,ForceMode.Impulse);
    }

    public void ImpulseSound(){
        FXImpulso.Play();
    }

    public void ShootLaser(){
        FXDisparo.Play();
		GameObject go = GameObject.Instantiate(m_shotPrefab, navedisp.position, navedisp.rotation) as GameObject;
        go.SetActive(true);
		try{
            GameObject.Destroy(go, 3f);
        }catch{
            print("Ya ha sido destruido");
        }
    }

    public void StartINB(){
        StartCoroutine(ImpulseNaveButton());
    }

    IEnumerator ImpulseNaveButton(){
        NextTimeSpawn = Time.time + SpawnDelay;
        while(NextTimeSpawn>=Time.time){
            ImpulseNave();
            yield return null;
        }
    }

    IEnumerator Final()
    {
        GameObject GMScore = GameObject.Find("ScoreGlobal");
        
        ScoreScript ScoreS = (ScoreScript)GMScore.GetComponent(typeof(ScoreScript));
        ScoreS.setScore(Score.text);
        float Hora = Time.time + 1;
        while (Hora >= Time.time)
        {
            yield return null;
        }
        SceneManager.LoadScene(3);

    }


}
