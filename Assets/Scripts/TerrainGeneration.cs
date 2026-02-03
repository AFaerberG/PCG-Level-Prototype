using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    Vector3Int[] generatedBlocks;
    Vector2 generationSeed;
    [SerializeField] int seedRange = 255;
    [SerializeField] int chunkSize = 10;
    [SerializeField] GameObject blockObject;

    private void Awake()
    {
        generationSeed = new Vector2(Random.Range(0f, seedRange), Random.Range(0f, seedRange));
        Debug.Log(generationSeed);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoiseGenerator(Chunk chunk)
    {
        chunk.initChunk(chunkSize);
        //generatedBlocks = new Vector3Int[chunkSize * chunkSize];
        for (int z = 0; z < chunkSize; z++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                //int yValue = Mathf.RoundToInt(Mathf.Abs(Mathf.PerlinNoise(x + generationSeed.x, z + generationSeed.y)) * 20);
                float yValue = Mathf.PerlinNoise((generationSeed.x / seedRange) + (x / (float)chunkSize), (generationSeed.y / seedRange) + (z / (float)chunkSize)) * 10;
                chunk.containedBlocks[z * chunkSize + x] = new Vector3Int(chunk.worldCoords.x * chunkSize + x, (int)yValue, chunk.worldCoords.y * chunkSize + z);
            }
        }
        PlaceBlocks(chunk);
    }

    void PlaceBlocks(Chunk parent)
    {
        foreach (Vector3Int block in parent.containedBlocks)
        {
            GameObject newBlock = Instantiate(blockObject, block, transform.rotation);
            newBlock.transform.SetParent(parent.transform);
        }
    }
}
