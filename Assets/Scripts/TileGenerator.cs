using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    Tile[,] _tiles = new Tile[10,10];
    Tile nothingTile = new Tile();
    [SerializeField] GenerationRules generationRules;

    private void Start()
    {
        nothingTile.prefabId = -1;

        for (int i = 0; i < _tiles.GetLength(0); i++)
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                _tiles[i,j].aroundTiles = new Tile[3,3];
                _tiles[i, j].prefabId = -1;
                _tiles[i, j].generationRules = generationRules;
                    }


                for (int i=0; i<_tiles.GetLength(0);i++)
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                for (int x = 0; x < 3; x++)
                    for (int y = 0; y < 3; y++)
                    {
                        if (i - 1 + x < 0 || i - 1 + x > _tiles.GetLength(0)-1 || j - 1 + y < 0 || j - 1 + y > _tiles.GetLength(1)-1)
                        {
                            _tiles[i, j].aroundTiles[x, y] = nothingTile;
                            continue;
                        }
                        _tiles[i, j].aroundTiles[x, y] = _tiles[i - 1 + x, j - 1 + y];
                    }
                Debug.Log(i);
                Debug.Log(j);
                _tiles[i,j].GenerateNewState();

            }


        int[,] ids = new int[10,10];


        for (int i = 0; i < _tiles.GetLength(0); i++)
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                ids[i, j] = _tiles[i, j].prefabId;
            }

        for (int i = 0;i<10;i++)
        Debug.Log(ids[0,i]+ " " + ids[1,i]+" " + ids[2, i] + " " + ids[3, i] + " " + ids[4, i] + " " + ids[5, i] + " " + ids[6, i] + " " + ids[7, i] + " " + ids[7, i] + " " + ids[8, i] + " " + ids[9, i] + " ");
        
    }
}
