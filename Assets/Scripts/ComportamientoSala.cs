using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoSala : MonoBehaviour {

    public GameObject[] muro; // 0- top, 1- down, 2- left, 3- right
    public GameObject[] puerta;


    // Update is called once per frame
    public void UpdateSala(bool[] status) {
        for (int i = 0; i < status.Length; i++) {
            puerta[i].SetActive(status[i]);
            muro[i].SetActive(!status[i]);
        }
    }
}
