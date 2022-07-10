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
    public GenerationRules antiGenerationRules;

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
       if( CheckRule(_aroundTiles, generationRules.GetData(i),generationRules.generationRule[i].superPositionTreasHold) 
                && Random.Range(0f,1f) < generationRules.generationRule[i].chance)
            {

                bool antiRulesCheck = false;

                for (int j = 0; j < antiGenerationRules.generationRule.Length; j++)
                    if (CheckAntiRule(_aroundTiles, antiGenerationRules.GetData(j), antiGenerationRules.generationRule[j].superPositionTreasHold, generationRules.GetData(i)[1, 1]))
                        antiRulesCheck = true;

                if (antiRulesCheck) continue;
                        
                prefabId = generationRules.GetData(i)[1, 1];


                //Debug.Log("New" + prefabId);
                continue;
            }
           
        }
    }



    bool CheckRule(int[,] _aroundTiles, int[,] _rule, int superPositionTreashHold)
    {
        int _superPositionCounter = 0;
        
        for (int i=0; i<3;i++)
            for (int j=0; j < 3; j++)
            {
                if (i==1 && j==1)
                    continue;
                if (_aroundTiles[i, j] == -1 || _rule[i, j] == -1)
                {
                    if (_aroundTiles[i, j] == -1 && _rule[i, j] != -1)
                        _superPositionCounter++;

                    if (_superPositionCounter > superPositionTreashHold)
                        return false;

                    continue;
                }
                if (_aroundTiles[i, j] != _rule[i, j]) 
                    return false;
            }

        return true;
    }

    bool CheckAntiRule(int[,] _aroundTiles, int[,] _antiRule, int superPositionTreashHold, int idToCheck)
    {
        int _superPositionCounter = 0;

        if (idToCheck != _antiRule[1, 1]) return false;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                if (i == 1 && j == 1)
                    continue;

                if (_aroundTiles[i, j] == -1 || _antiRule[i, j] == -1)
                {
                    if (superPositionTreashHold > -1)
                    {
                        if (_aroundTiles[i, j] == -1 && _antiRule[i, j] != -1)
                            _superPositionCounter++;

                        if (_superPositionCounter > superPositionTreashHold)
                        {

                            return false;
                        }
                    }
                    continue;
                }
                if (_aroundTiles[i, j] != _antiRule[i, j])                
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
