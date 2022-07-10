using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ScriptableObjectives", menuName = "ScriptableObjects/ScriptableObjectives", order = 3)]
public class ScriptableObjectives : ScriptableObject
{
    public Vector3 firstPoint;
    public bool firstObjectActivated;
    public GameObject firstPointObject;

    public Vector3 lastPoint;
    public bool lastObjectActivated;
    public GameObject lastPointObject;

}
