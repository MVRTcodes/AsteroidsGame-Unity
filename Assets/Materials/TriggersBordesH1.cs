using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersBordesH1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);

        if (other.gameObject.name.Equals("Capsule"))
        {
            other.transform.parent.parent.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z-50);
            
        }
    }
}
