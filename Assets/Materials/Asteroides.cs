using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Asteroides : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject explosionFX;

    public int tiempoesp;

    private Text Score;

    private int ScoreInt;
    void Start()
    {
        GameObject GMScore = GameObject.Find("TextScore");
        Score = GMScore.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider collision) {
            
        if(collision.gameObject.name.Equals("ColUTUM")){

            GameObject o = GameObject.Instantiate(explosionFX, transform.position, transform.rotation) as GameObject;
            o.SetActive(true);
            GameObject.Destroy(o,1f);
            //Destroy(collision.gameObject);
            gameObject.SetActive(false);
            ScoreInt = Int32.Parse(Score.text);
            ScoreInt += 10;
            Score.text = ScoreInt.ToString();
            
        }
    }




}
