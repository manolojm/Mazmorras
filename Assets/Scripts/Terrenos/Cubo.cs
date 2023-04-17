using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Physics.Raycast(transform.position, transform.up) &&
            Physics.Raycast(transform.position, transform.right
            )


            )
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        
    }

   
}
