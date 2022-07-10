using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChanger : MonoBehaviour
{
  
    [SerializeField] private PrefabSet _prefabSet;
    [SerializeField] private GameObject[] _variants;
    [SerializeField] private GameObject _currentVariant;
    public Tile tile;

    private void Start()
    {
        _currentVariant.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (tile.prefabId != -1) return;

        if (other.gameObject.tag == "Player") 
            ChangeTile();    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tile.prefabId = -1;
            _currentVariant.SetActive(false);

        }
    }


    

    public void ChangeTile()
    {
        _currentVariant.SetActive(false);
        tile.GenerateNewState();
        _currentVariant = _variants[tile.prefabId];//_variants[Random.Range(0, _variants.Length-1)];
        _currentVariant.SetActive(true);
    }

   public void UpdateTile()
    {
        if (tile.prefabId == -1) { _currentVariant.SetActive(false); return; }

        _currentVariant.SetActive(false);
        _currentVariant = _variants[tile.prefabId];
        _currentVariant.SetActive(true);
    }

    public void MakeDisable()
    {
        tile.prefabId = -1;
        UpdateTile();
    }
}
