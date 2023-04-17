using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public int alto, largo, ancho;
    public GameObject cubo;
    public int detalle;
    public int seed;


    // Start is called before the first frame update
    void Start()
    {
       // seed = Random.Range(100000, 900000);
        GeneraMapa();   
    }

    public void GeneraMapa()
    {
        
        for (int i = 0; i < largo; i++)
        {
            for (int j = 0; j < ancho; j++)
            {
                alto = (int)(Mathf.PerlinNoise(((float)i   + seed )/ detalle , ((float)j  + seed) / detalle)* detalle);
                for (int k = 0; k < alto; k++)
                {
                    GameObject actual = Instantiate(cubo, new Vector3(i, k, j), Quaternion.identity);
                    AplicaTextura(actual, k);
                }
            }

        }
    }

    public void AplicaTextura(GameObject cubo, int altura)
    {
        if (altura == 0) // Agua
            cubo.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        else if (altura < 15)
            cubo.GetComponent<MeshRenderer>().materials[0].color = Color.green;
        else if (altura < 25)
            cubo.GetComponent<MeshRenderer>().materials[0].color = new Color(0.5f, 0.5f, 0);
        else
            cubo.GetComponent<MeshRenderer>().materials[0].color = Color.white;
    }



}
