using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChanger : MonoBehaviour
{
    private Tile _tile;
    [SerializeField] private PrefabSet _prefabSet;
    [SerializeField] private GameObject[] _variants;
    [SerializeField] private GameObject _currentVariant;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
            ChangeTile();    
    }

    private void OnTriggerExit(Collider other) =>
        _currentVariant.SetActive(false);

    private void OnBecameInvisible() =>
        _currentVariant.SetActive(false);

    private void ChangeTile()
    {
        _currentVariant.SetActive(false);
        _currentVariant = _variants[Random.Range(0, _variants.Length-1)];
        _currentVariant.SetActive(true);
    }
}
