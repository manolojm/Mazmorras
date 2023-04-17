using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pintaTerrain : MonoBehaviour
{
    [System.Serializable]
    public class TexturaAltura
    {
        public int indiceTextura;
        public int alturaInicio;
    }

    public TexturaAltura[] texturaAltura;

    void Start()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,,] datosMapa = new float[terrainData.alphamapWidth,
                                            terrainData.alphamapHeight,
                                            terrainData.alphamapLayers];

        for(int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for(int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float alturaTerreno = terrainData.GetHeight(y, x);
                
                float[] pinta = new float[texturaAltura.Length];
                
                for(int i = 0; i< texturaAltura.Length; i++)
                {
                    if (alturaTerreno >= texturaAltura[i].alturaInicio)
                        pinta[i] = 1;
                }

                for(int j = 0; j < texturaAltura.Length; j++)
                {
                    datosMapa[x, y, j] = pinta[j];
                }

                
            }

        }

        terrainData.SetAlphamaps(0, 0, datosMapa);

    }
   
}
