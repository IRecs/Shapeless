using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTpBack : MonoBehaviour
{
    [SerializeField] private PlayerPositionChecker _playerPositionChecker;
    [SerializeField] private GameObject _middleTile;
    [SerializeField] private Vector2Int _middleTileCoords;
    [SerializeField] private int _visionRadius;
    [SerializeField] private Rigidbody rigidbody;
    private bool teleport;


    private void Start()
    {if (rigidbody==null)
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("BORDER!");
            StartCoroutine(TpPlayer());
        }
    }


    IEnumerator TpPlayer()
    {
        TpPlayerToMiddleTile();
        yield return new WaitForEndOfFrame();
             
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Border")
        {
            Debug.Log("BORDER!");
            StartCoroutine(TpPlayer());
        }
    }
    
  

    void TpPlayerToMiddleTile()
    {

        RespawnTiles();
        gameObject.transform.SetParent(_playerPositionChecker.lastTile.transform);
        Vector3 tempLocalPos = transform.localPosition;
        Debug.Log(transform.localPosition);
        

        gameObject.transform.SetParent(_middleTile.transform);
        transform.localPosition = tempLocalPos;

        Debug.Log("2 "+transform.localPosition);
        gameObject.transform.SetParent(null);


       // gameObject.transform.position += new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
    }

    void RespawnTiles()
    {
        Tile _playerTile  = _playerPositionChecker.lastTile.GetComponent<TileChanger>()?.tile;
        
        if (_playerTile == null) return;

        Tile[,] _tiles = _playerTile.tilesBase;

        int xPosPlayer = _playerTile.xPos;
        int yPosPlayer = _playerTile.yPos;

        for (int i = 0; i<= _visionRadius*2+1;i++)
            for (int j = 0; j <= _visionRadius*2+1; j++)
                 {
                Tile oldTile = _tiles[xPosPlayer - _visionRadius + i, yPosPlayer - _visionRadius + j];
                Tile newTile = _tiles[_middleTileCoords.x - _visionRadius + i, _middleTileCoords.y - _visionRadius + j];

                int tempPrefabId = oldTile.prefabId;

              
               

                oldTile.tileChanger.MakeDisable();

                newTile.prefabId = tempPrefabId;
                newTile.tileChanger.UpdateTile();
            }

    }


}
