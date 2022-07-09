using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionChecker : MonoBehaviour
{
    public GameObject lastTile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            lastTile = other.gameObject;
           
    }
}
