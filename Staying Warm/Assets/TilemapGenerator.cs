using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap backTilemap;
    public Tilemap frontTilemap;
    public Tile[] snow;
    public Tile barrier;

    public float xRange;
    public float yRange;


    void Start()
    {
        PlaceSnowTiles();
    }
   
    void PlaceSnowTiles()
    {
        for (int x = 0; x < xRange; x++)
        {
            for (int y = 0; y < xRange; y++)
            {
                if (x == xRange - 1 || y == yRange - 1)
                {
                    Vector3Int position = new Vector3Int(x, y, 0);
                    frontTilemap.SetTile(position, barrier);
                    position = new Vector3Int(-x, y, 0);
                    frontTilemap.SetTile(position, barrier);
                    position = new Vector3Int(x, -y, 0);
                    frontTilemap.SetTile(position, barrier);
                    position = new Vector3Int(-x, -y, 0);
                    frontTilemap.SetTile(position, barrier);
                }
                else
                {
                    Vector3Int position = new Vector3Int(x, y, 0);
                    backTilemap.SetTile(position, snow[Random.Range(0, snow.Length)]);
                    position = new Vector3Int(-x, y, 0);
                    backTilemap.SetTile(position, snow[Random.Range(0, snow.Length)]);
                    position = new Vector3Int(x, -y, 0);
                    backTilemap.SetTile(position, snow[Random.Range(0, snow.Length)]);
                    position = new Vector3Int(-x, -y, 0);
                    backTilemap.SetTile(position, snow[Random.Range(0, snow.Length)]);
                }

            }
        }
    }
}
