using UnityEngine;

public class ChunkProximity : MonoBehaviour
{
    Vector3 prevPos;
    [SerializeField] TerrainGenerator terrainGen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckDiff(transform.position);
        prevPos = transform.position;
    }

    private void CheckDiff(Vector3 currentPos)
    {
        if ((currentPos.x != prevPos.x) && (currentPos.z != prevPos.z))
        {
            Vector2Int currentChunk = terrainGen.WorldToChunkPos(currentPos);
            foreach (var terrain in Terrain.activeTerrains)
            {
                Vector2Int terrainChunk = terrainGen.WorldToChunkPos(terrain.GetPosition());
                if (currentChunk == terrainChunk)
                {
                    return;
                }
            }
            terrainGen.GenerateChunk(terrainGen.ChunkToWorldPos(currentChunk));
        }
    }
}
