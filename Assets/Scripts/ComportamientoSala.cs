using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoSala : MonoBehaviour
{
    public GameObject[] muros;
    public GameObject[] puertas;

    public void UpdateSala(bool[] status) {
        for (int i = 0; i < status.Length; i++) {
            puertas[i].SetActive(status[i]);
            muros[i].SetActive(!status[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
