using System.Collections;
using System.Collections.Generic;
using PlayerFolder;
using UnityEngine;

public class PlayerTpBack : MonoBehaviour
{
	[SerializeField] private PlayerPositionChecker _playerPositionChecker;
	[SerializeField] private GameObject _middleTile;
	[SerializeField] private Vector2Int _middleTileCoords;
	[SerializeField] private int _visionRadius;
	[SerializeField] private MoverPlayer _playerMover;
	private bool _teleport;
	
	private void OnCollisionEnter(Collision collision)
	{

		if(collision.gameObject.tag == "Border")
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


		if(other.gameObject.tag == "Border")
		{
			Debug.Log("BORDER!");
			StartCoroutine(TpPlayer());
		}
	}


	void TpPlayerToMiddleTile()
	{
		RespawnTiles();
		transform.SetParent(_playerPositionChecker.lastTile.transform);
		Vector3 tempLocalPos = transform.localPosition;
		transform.SetParent(_middleTile.transform);
		_playerMover.Warp(tempLocalPos);
		transform.SetParent(null);
	}

	void RespawnTiles()
	{
		Tile _playerTile = _playerPositionChecker.lastTile.GetComponent<TileChanger>()?.tile;

		if(_playerTile == null) return;

		Tile[,] _tiles = _playerTile.tilesBase;

		int xPosPlayer = _playerTile.xPos;
		int yPosPlayer = _playerTile.yPos;

		for( int i = 0; i <= _visionRadius * 2 + 1; i++ )
		for( int j = 0; j <= _visionRadius * 2 + 1; j++ )
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