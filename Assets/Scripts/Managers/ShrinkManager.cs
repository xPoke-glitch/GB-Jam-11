using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShrinkManager : Singleton<ShrinkManager>
{
    [SerializeField]
    private Tilemap _collisionTilemap;
    [SerializeField]
    private Tilemap _baseTilemap;
    [SerializeField]
    private TileBase _tileWarning;
    [SerializeField]
    private TileBase _tile;

    private int _xShrinkIndex = 0;
    private int _yShrinkIndex = 0;

    public void StartManager()
    {
        InvokeRepeating("Shrink", 2, 2);
    }

    private void Shrink()
    {
        foreach (var pos in _collisionTilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = _collisionTilemap.CellToWorld(localPlace);
            if ((pos.x == _collisionTilemap.cellBounds.xMin + _xShrinkIndex) ||
                (pos.x == _collisionTilemap.cellBounds.xMax - _xShrinkIndex-1) ||
                (pos.y == _collisionTilemap.cellBounds.yMin + _yShrinkIndex) ||
                (pos.y == _collisionTilemap.cellBounds.yMax - _yShrinkIndex-1)
                )
            {
                // Show warning tile
                _baseTilemap.SetTile(localPlace, _tileWarning);
                // Wait for a bit ...
                StartCoroutine(COFinalSet(localPlace));
            }
        }
        _xShrinkIndex++;
        _yShrinkIndex++;
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += StopShrink;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopShrink;
    }

    private void StopShrink(bool isWin)
    {
        CancelInvoke();
    }

    private IEnumerator COFinalSet(Vector3Int pos)
    {
        yield return new WaitForSeconds(2);
        // Spawn collider tile
        _baseTilemap.SetTile(pos, null);
        _collisionTilemap.SetTile(pos, _tile);

        // Find if in there there is the player
        Collider2D[] collisions = Physics2D.OverlapCircleAll(new Vector2(pos.x, pos.y), 0.5f);
        foreach(Collider2D col in collisions)
        {
            Actor actor = null;
            if (col.gameObject.TryGetComponent(out actor))
            {
                actor.Die();
            }
        }
    }

}
