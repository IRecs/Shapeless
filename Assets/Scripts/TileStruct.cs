using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile
{
    public Tile[,] aroundTiles;




    public int prefabId;
    public GenerationRules generationRules;

    public void GenerateNewState()
    {


        int[,] _aroundTiles = new int[3,3];

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                _aroundTiles[i, j] = aroundTiles[i, j].prefabId;


                for (int i = 0; i < generationRules.generationRule.Length; i++)
        { 
       if( CheckRule(_aroundTiles, generationRules.GetData(i)))
            {
                prefabId = generationRules.GetData(i)[1, 1];
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
