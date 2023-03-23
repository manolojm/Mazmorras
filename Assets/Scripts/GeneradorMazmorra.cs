using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMazmorra : MonoBehaviour
{
    public class Celda {
        public bool visitada = false;
        public bool[] status = new bool[4];
    }

    public Vector2Int size;
    public int posicionInicio = 0;
    public GameObject sala;
    public Vector2 dimension;

    List<Celda> tablero;

    // Start is called before the first frame update
    void Start()
    {
        GeneradorLaberinto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneraMazmorra() {
        for (int i = 0; i < size.x; i++) {
            for (int j = 0; j < size.y; j++) {
                //var nuevaSala = Instantiate(sala, new Vector3(i * dimension.x, 0, j * dimension.y), Quaternion.identity, transform).GetComponent<ComportamientoSala>;
                //nuevaSala.UpdateSala(tablero[i + j * size.x].status);
            }
        }
    }

    void GeneradorLaberinto() {
        tablero = new List<Celda>();
        for (int i = 0; i < size.x; i++) {
            for (int j = 0; i < size.y; i++) {
                tablero.Add(new Celda());
            }
        }

        int celdaActual = posicionInicio;
        Stack<int> camino = new Stack<int>();
        int num = 0;
        while(num < 100) {
            num++;
        }
    }

    void CompruebaVecinos(int celda) {
        List<int> vecinos = new List<int>();

        // Comprobar vecinos de arriba
        if (celda - size.x >= 0 && !tablero[celda - size.x].visitada) {
            vecinos.Add(celda - size.x);
        }
        
    }
}
