using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTpBack : MonoBehaviour
{
    [SerializeField] private PlayerPositionChecker _playerPositionChecker;
    [SerializeField] private GameObject _middleTile;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log("BORDER!");
            TpPlayerToMiddleTile();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        
            if (other.gameObject.tag == "Border")
            {
               
                TpPlayerToMiddleTile();
            }
        
    }

    void TpPlayerToMiddleTile()
    {
        gameObject.transform.SetParent(_playerPositionChecker.lastTile.transform);
        Vector3 tempLocalPos = transform.localPosition;
        gameObject.transform.SetParent(_middleTile.transform);
        transform.localPosition = tempLocalPos;
        gameObject.transform.SetParent(null);
    }

}
