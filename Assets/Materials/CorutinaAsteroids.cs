using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutinaAsteroids : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadmov = 1f;
    public Transform objetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Corutina(objetivo));
    }
    
    IEnumerator Corutina(Transform target){
        while(target.gameObject.activeSelf){
            transform.position = Vector3.Lerp(transform.position, target.position, velocidadmov * Time.deltaTime);
            yield return null;
        }
        print("Prueba realizada");
        Destroy(this.gameObject,1f);
    }

    
}
