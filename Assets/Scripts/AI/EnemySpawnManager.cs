using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum EnemyType
{
    Melee,
    Ranged
}

[Serializable]
public struct EnemyStruct
{
    public Vector3 Position;
    public EnemyType Type;
}

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField]
    private float _spawnTime = 5.0f;

    [Header("Pool references")]
    [SerializeField]
    private Transform _rangedEnemyParent;
    [SerializeField]
    private Transform _meleeEnemyParent;

    [Header("Settings")]
    [SerializeField]
    private List<EnemyStruct> _enemiesStartPositions = new List<EnemyStruct>();

    private ObjectPool<Enemy> _rangedPool;
    private ObjectPool<Enemy> _meleePool;

    private void Awake()
    {
        _rangedPool = new ObjectPool<Enemy>(RangedEnemyFactory, TurnOnEnemy, TurnOffEnemy, 10, true);
        _meleePool = new ObjectPool<Enemy>(MeleeEnemyFactory, TurnOnEnemy, TurnOffEnemy, 10, true);
    }

    void Start()
    {
        foreach (EnemyStruct position in _enemiesStartPositions)
        {
            switch (position.Type)
            {
                case EnemyType.Melee:
                    _meleePool.GetObject().SetupEnemy(position.Position, Quaternion.identity, _meleePool);
                    break;

                case EnemyType.Ranged:
                    _rangedPool.GetObject().SetupEnemy(position.Position, Quaternion.identity, _rangedPool);
                    break;
            }
        }

        InvokeRepeating("SpawnEnemy",_spawnTime,_spawnTime);
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += StopSpawn;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopSpawn;
    }

    public void StopSpawn(bool isWin)
    {
        CancelInvoke();
        Destroy(_rangedEnemyParent.gameObject);
        Destroy(_meleeEnemyParent.gameObject);
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

        if (freeTiles.Count <= 0)
            return;

        int randIndex = UnityEngine.Random.Range(0,freeTiles.Count);
        if (UnityEngine.Random.Range(0, 2) == 0)
            _meleePool.GetObject().SetupEnemy(new Vector3(freeTiles[randIndex].x + 0.5f, freeTiles[randIndex].y + 0.5f, freeTiles[randIndex].z), Quaternion.identity, _meleePool);
        else
            _rangedPool.GetObject().SetupEnemy(new Vector3(freeTiles[randIndex].x + 0.5f, freeTiles[randIndex].y + 0.5f, freeTiles[randIndex].z), Quaternion.identity, _rangedPool);
    }

    private Enemy RangedEnemyFactory()
    {
        return Instantiate(_enemies[1], _rangedEnemyParent).GetComponent<Enemy>();
    }

    private Enemy MeleeEnemyFactory()
    {
        return Instantiate(_enemies[0], _meleeEnemyParent).GetComponent<Enemy>();
    }

    private void TurnOnEnemy(Enemy enemy) => enemy.gameObject.SetActive(true);

    private void TurnOffEnemy(Enemy enemy) => enemy.gameObject.SetActive(false);
}
