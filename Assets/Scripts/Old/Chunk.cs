using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2Int worldCoords;
    int chunkSize = 10;
    public Vector3Int[] containedBlocks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<TerrainGeneration>().NoiseGenerator(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initChunk(int chunkWidth)
    {
        chunkSize = chunkWidth;
        worldCoords = new Vector2Int((int)transform.position.x / chunkSize, (int)transform.position.y / chunkSize);
        containedBlocks = new Vector3Int[chunkSize * chunkSize];
    }
}
