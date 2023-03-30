using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMazmorra : MonoBehaviour {

    public class Celda {
        public bool visitada = false;
        public bool[] status = new bool[4];
    }

    public Vector2Int size;
    public int posInicio = 0;
    public GameObject sala;
    public Vector2Int offset;

    List<Celda> tablero;

    // Start is called before the first frame update
    void Start() {
        GeneraLaberinto();
    }

    void GeneraMazmorra() {
        for (int i = 0; i < size.x; i++) {
            for (int j = 0; j < size.y; j++) {
                Celda celdaActual = tablero[i + j * size.x];
                if (celdaActual.visitada) {
                    var nuevaSala = Instantiate(sala, new Vector3(i * offset.x, 0, j * offset.y), Quaternion.identity, transform).GetComponent<ComportamientoSala>();
                    nuevaSala.UpdateSala(tablero[i + j * size.x].status);
                }
            }
        }
    }

    void GeneraLaberinto() {
        tablero = new List<Celda>();

        for (int i = 0; i < size.x; i++) {
            for (int j = 0; j < size.y; j++) {
                tablero.Add(new Celda());
            }
        }

        int celdaActual = posInicio;

        Stack<int> camino = new Stack<int>();

        int num = 0;

        while (num < 20) {
            num++;

            tablero[celdaActual].visitada = true;


            // Comprbobamos los vecinos
            List<int> vecinos = CompruebaVecinos(celdaActual);

            if (vecinos.Count == 0) {
                if (camino.Count == 0) {
                    break;
                } else {
                    celdaActual = camino.Pop();
                }
            } else {
                camino.Push(celdaActual);

                int nuevaCelda = vecinos[Random.Range(0, vecinos.Count)];

                if (nuevaCelda > celdaActual) {
                    // Abajo o derecha
                    if (nuevaCelda - 1 == celdaActual) {
                        tablero[celdaActual].status[3] = true;
                        celdaActual = nuevaCelda;
                        tablero[celdaActual].status[2] = true;
                    } else {
                        tablero[celdaActual].status[0] = true;
                        celdaActual = nuevaCelda;
                        tablero[celdaActual].status[1] = true;
                    }
                } else {
                    // Arriba o izquierda
                    if (nuevaCelda + 1 == celdaActual) {
                        tablero[celdaActual].status[2] = true;
                        celdaActual = nuevaCelda;
                        tablero[celdaActual].status[3] = true;
                    } else {
                        tablero[celdaActual].status[1] = true;
                        celdaActual = nuevaCelda;
                        tablero[celdaActual].status[0] = true;
                    }
                }
            }
        }

        GeneraMazmorra();
    }


    List<int> CompruebaVecinos(int celda) {
        List<int> vecinos = new List<int>();

        // Comprobamos vecino de arriba
        if (celda - size.x >= 0 && !tablero[(celda - size.x)].visitada) {
            vecinos.Add(celda - size.x);
        }


        // comprobamos vecino de abajo
        if (celda + size.x < tablero.Count && !tablero[celda + size.x].visitada) {
            vecinos.Add((celda + size.x));
        }

        // combobamos vecino de la derecha
        if ((celda + 1) % size.x != 0 && !tablero[celda + 1].visitada) {
            vecinos.Add(celda + 1);
        }

        // Comprobamos el vecino de la izquieda
        if ((celda) % size.x != 0 && !tablero[celda - 1].visitada) {
            vecinos.Add(celda - 1);
        }

        return vecinos;
    }
}
