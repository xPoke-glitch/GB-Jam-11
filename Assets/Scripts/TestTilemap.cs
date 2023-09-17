using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTilemap : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private TileBase _tile;

    private int _xShrinkIndex = 0;
    private int _yShrinkIndex = 0;

    void Start()
    {
        InvokeRepeating("Shrink", 5, 5);
    }

    private void Shrink()
    {
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = _tilemap.CellToWorld(localPlace);
            if ((pos.x == _tilemap.cellBounds.xMin + _xShrinkIndex) ||
                (pos.x == _tilemap.cellBounds.xMax - _xShrinkIndex-1) ||
                (pos.y == _tilemap.cellBounds.yMin + _yShrinkIndex) ||
                (pos.y == _tilemap.cellBounds.yMax - _yShrinkIndex-1)
                )
            {
                _tilemap.SetTile(localPlace, _tile);
            }
        }
        _xShrinkIndex++;
        _yShrinkIndex++;
    }

}
