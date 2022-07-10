using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int xPos;
    public int yPos;
    public GameObject tileObject;
    public TileChanger tileChanger;
   
    public Tile[,] tilesBase;



    public int prefabId;
    public GenerationRules generationRules;

    public void GenerateNewState()
    {


        int[,] _aroundTiles = new int[3,3];

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                if (xPos - 1 + i < 0 || xPos - 1 + i > tilesBase.GetLength(0) || yPos - 1 + j < 0 || yPos - 1 + j > tilesBase.GetLength(1))
                {
                    _aroundTiles[i, j] = -1;
                    continue;
                        }
                
                _aroundTiles[i, j] = tilesBase[xPos - 1 + i, yPos - 1 + j].prefabId;
                //Debug.Log(_aroundTiles[i, j] + " "+ tilesBase[xPos - 1 + i, yPos - 1 + j].xPos+ " "+ tilesBase[xPos - 1 + i, yPos - 1 + j].yPos + " "+ tilesBase[xPos - 1 + i, yPos - 1 + j].prefabId);
                    //aroundTiles[i, j].prefabId;
            }

                for (int i = 0; i < generationRules.generationRule.Length; i++)
        { 
       if( CheckRule(_aroundTiles, generationRules.GetData(i)) && Random.Range(0f,1f) < generationRules.generationRule[i].chance)
            {
                prefabId = generationRules.GetData(i)[1, 1];
                //Debug.Log("New" + prefabId);
                continue;
            }
           
        }
    }



    bool CheckRule(int[,] _aroundTiles, int[,] _rule)
    {
        
        for (int i=0; i<3;i++)
            for (int j=0; j < 3; j++)
            {
                if (i==1 && j==1)
                    continue;
                if (_aroundTiles[i, j] == -1 || _rule[i, j] == -1) 
                    continue;
                if (_aroundTiles[i, j] != _rule[i, j]) 
                    return false;
            }

        return true;
    }

}

public class TileStruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
