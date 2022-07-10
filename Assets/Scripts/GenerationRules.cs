using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenerationRules", menuName = "ScriptableObjects/GenerationRules", order = 2)]
public class GenerationRules : ScriptableObject
{

    public Vec3AsGridCostil[] generationRule;


    public int[,] GetData(int id)
    {
        int[,] _data = new int[3, 3];

        _data[0, 0] = generationRule[id].line1.z;
        _data[0, 1] = generationRule[id].line1.y;
        _data[0, 2] = generationRule[id].line1.x;

        _data[1, 0] = generationRule[id].line2.z;
        _data[1, 1] = generationRule[id].line2.y;
        _data[1, 2] = generationRule[id].line2.x;

        _data[2, 0] = generationRule[id].line3.z;
        _data[2, 1] = generationRule[id].line3.y;
        _data[2, 2] = generationRule[id].line3.x;

        return _data;
    }


}
