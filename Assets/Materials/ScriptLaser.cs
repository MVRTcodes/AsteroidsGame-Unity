using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision){
        
        
        if (collision.gameObject.name.StartsWith("Asteroid")){
            
            Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
            
        }
        
    }
}
