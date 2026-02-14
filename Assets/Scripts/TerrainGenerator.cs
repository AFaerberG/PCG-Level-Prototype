using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    //TerrainData terrainData;
    [SerializeField] Terrain baseTerrain;
    public int chunkSize = 64;
    [SerializeField] int chunkHeight = 64;

    [SerializeField] float scaleX = 1.0f;
    [SerializeField] float scaleY = 1.0f;
    [SerializeField] float scaleZ = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //terrainData = baseTerrain.terrainData;
        //GenerateHeightmap();
        //GenerateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        //GenerateHeightmap();
    }

    void GenerateHeightmap(Vector3 worldCoords, TerrainData terrainData)
    {
        terrainData.heightmapResolution = chunkSize + 1;
        terrainData.size = new Vector3(chunkSize, chunkHeight, chunkSize);
        float[,] heights = new float[chunkSize + 1, chunkSize + 1];
        for (int x = 0; x < chunkSize + 1; x++)
        {
            for (int z = 0; z < chunkSize + 1; z++)
            {
                heights[z, x] = Mathf.PerlinNoise(((x + worldCoords.x) / chunkHeight ) * scaleX, ((z + worldCoords.z) / chunkSize) * scaleZ) * scaleY;
            }
        }
        terrainData.SetHeights(0, 0, heights);
    }

    public void GenerateChunk(Vector3 worldPosition)
    {
        TerrainData newTerrainData = new TerrainData();
        GenerateHeightmap(worldPosition, newTerrainData);
        GameObject newTerrainObject = Terrain.CreateTerrainGameObject(newTerrainData);
        newTerrainObject.transform.position = worldPosition;        
        //newTerrain.SetNeighbors();
    }

    public Vector2Int WorldToChunkPos(Vector3 worldPos)
    {
        Vector3Int vector = Vector3Int.FloorToInt(worldPos / chunkSize);
        Vector2Int output = new Vector2Int(vector.x, vector.z);
        return output;
    }

    public Vector3 ChunkToWorldPos(Vector2Int chunkPos)
    {
        Vector3 output = new Vector3(chunkPos.x, 0, chunkPos.y);
        output *= chunkSize;
        return output;
    }
}
