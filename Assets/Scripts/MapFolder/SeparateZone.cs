using System;
using UnityEngine;

public class SeparateZone : MonoBehaviour
{
    public Vector2Int Position;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    public void Spawn()
    {
        Vector3 bias = transform.localScale / 2;
        Vector3 startPosition = transform.position -= bias;
    }
}
