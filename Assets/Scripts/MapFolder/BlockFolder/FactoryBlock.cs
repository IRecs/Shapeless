using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MapFolder.BlockFolder
{
	public class FactoryBlock
	{
		private readonly AssetContainer _assetContainer;
	
		public FactoryBlock(AssetContainer assetContainer) =>
			_assetContainer = assetContainer;

		public Block GetBlock(BlockData blockData)
		{
			Block asset = blockData.Type switch
			{
				BlockType.Floor => _assetContainer.Floors[0],
				BlockType.Wall => _assetContainer.Walls[0],
				BlockType.Door => _assetContainer.Doors[0],
				_ => throw new ArgumentOutOfRangeException(),
			};

			Block newBlock = Object.Instantiate(asset, Vector3.zero, Quaternion.identity);
			BlockData newBlockData = new(blockData.Position, asset.Data.Type);
			newBlock.Initialization(newBlockData);
			newBlock.gameObject.SetActive(false);
			return newBlock;
		}
	}
}