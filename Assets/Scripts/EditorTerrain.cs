using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTerrain : MonoBehaviour
{
    public Terrain terreno;
    private float[,] matriz;
    public int resolucionMapa;
    public int dimensionMapa;
    public int alturaMapa;
    public int detalle;
    public int seed;

    [SerializeField] private List<GameObject> trees;


    // Start is called before the first frame update
    void Start()
    {
        
        matriz = new float[resolucionMapa+1, resolucionMapa+1];
        GeneradorAlturas();
        // Aplicar la matriz al objeto de tipo Terrain
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        terrainData.heightmapResolution = resolucionMapa;
        terrainData.size = new Vector3(dimensionMapa, alturaMapa, dimensionMapa);
        terrainData.SetHeights(0, 0, matriz);

        Invoke("PintarArboles", 1f);
    }


    public void GeneradorAlturas()
    {
        for(int i = 0; i < resolucionMapa; i++)
        {
            for (int j = 0; j < resolucionMapa; j++)
            {
                matriz[i, j] = Mathf.PerlinNoise(((float)i + seed) / detalle, ((float)j + seed)/ detalle);   
            }
        }   
    }

    public void PintarArboles() {
        //var terrain = GetComponentInChildren<Terrain>();
        var terrainData = terreno.terrainData;

        //foreach (var terrainTree in terrainData.treeInstances) {
        for (int i = 0; i < 30; i++) {

            var worldTreePos = Vector3.Scale(terrainData.treeInstances[i].position, terrainData.size) + Terrain.activeTerrain.transform.position;

            Debug.Log("Nuevo arbol ---> " + terrainData.treeInstances[i].position);

            var tree = Instantiate(trees[Random.Range(0, trees.Count)], worldTreePos, Quaternion.identity, transform);
            //tree.transform.localScale = Vector3.one * Random.Range(0, dimensionMapa);
            tree.transform.localScale = Vector3.one * 5;
            tree.transform.rotation = Quaternion.AngleAxis(Random.Range(-360f, 360f), Vector3.up);
        }
        terreno.treeDistance = 0;
    }

}
