using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField]
    private float _spawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",_spawnTime,_spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        List<Vector3> freeTiles = new List<Vector3>();

        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = _tilemap.CellToWorld(localPlace);
            if (!_tilemap.HasTile(localPlace))
            {
                freeTiles.Add(place);
            }
        }

        int randIndex = Random.Range(0,freeTiles.Count);
        Instantiate(_enemies[Random.Range(0, 2)], new Vector3(freeTiles[randIndex].x+0.5f, freeTiles[randIndex].y + 0.5f, freeTiles[randIndex].z), Quaternion.identity);
    }
}
