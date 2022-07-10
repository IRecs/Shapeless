using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesBase : MonoBehaviour
{
    public Tile[,] tiles;
    [SerializeField] private GenerationRules generationRules;
    [SerializeField] private GenerationRules antiGenerationRules;

    private void Start()
    {tiles =  new Tile[transform.childCount, transform.GetChild(0).childCount];

        for (int i = 0; i < tiles.GetLength(0); i++)
            for (int j = 0; j < tiles.GetLength(1); j++)
                tiles[i, j] = new Tile();

                StartTiles();
    }

    void StartTiles()
    {
        Transform lineParent;

        for (int i = 0; i < transform.childCount; i++)
        {
            lineParent = transform.GetChild(i);
            for (int j = 0; j < lineParent.childCount; j++)
            {
                tiles[i, j].tileObject = lineParent.GetChild(j).gameObject;
                tiles[i, j].tileChanger = lineParent.GetChild(j).GetComponent<TileChanger>();
                tiles[i, j].xPos = i;
                tiles[i, j].yPos = j;
                tiles[i, j].tilesBase = tiles;
                tiles[i, j].prefabId = -1;
                tiles[i, j].generationRules = generationRules;
                tiles[i, j].antiGenerationRules = antiGenerationRules;

                if (tiles[i, j].tileChanger != null)
                    tiles[i, j].tileChanger.tile = tiles[i,j];
            }



           }
    }
}
