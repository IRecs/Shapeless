using System;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

namespace MapFolder.BlockFolder
{
	public class Block : MonoBehaviour
	{
		public event Action<Block> INeedChange;

		public BlockData Data { get; private set; }

		public void Initialization(BlockData data) =>
			Data = data;

		[Button()]
		public void Test() =>
			INeedChange?.Invoke(this);

		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer == 7)
				INeedChange?.Invoke(this);
		}

		private void OnTriggerExit(Collider other)
		{
			if(other.gameObject.layer == 8)
				gameObject.SetActive(false);
		}
		
		private void OnDisable() =>
			INeedChange = null;
	}

	public enum BlockType
	{
		Floor = 0,
		Wall = 1,
		Door = 2,
	}
}