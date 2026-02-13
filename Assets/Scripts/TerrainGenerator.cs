using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    Terrain terrain;
    [SerializeField] int chunkSize = 64;
    [SerializeField] int chunkHeight = 64;

    [SerializeField] float scaleX = 1.0f;
    [SerializeField] float scaleY = 1.0f;
    [SerializeField] float scaleZ = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateHeightmap();
    }

    // Update is called once per frame
    void Update()
    {
        //GenerateHeightmap();
    }

    void GenerateHeightmap()
    {
        Vector3 worldCoords = transform.position;
        terrain.terrainData.heightmapResolution = chunkSize + 1;
        terrain.terrainData.size = new Vector3(chunkSize, chunkHeight, chunkSize);
        float[,] heights = new float[chunkSize + 1, chunkSize + 1];
        for (int x = 0; x < chunkSize + 1; x++)
        {
            for (int z = 0; z < chunkSize + 1; z++)
            {
                heights[z, x] = Mathf.PerlinNoise(((x + worldCoords.x) / chunkHeight ) * scaleX, ((z + worldCoords.z) / chunkSize) * scaleZ) * scaleY;
            }
        }
        terrain.terrainData.SetHeights(0, 0, heights);
    }
}
