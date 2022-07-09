using UnityEngine;

namespace MapFolder.BlockFolder
{
	public struct BlockData
	{
		public Vector2Int Position;
		public BlockType Type;

		public BlockData(Vector2Int position, BlockType type)
		{
			Position = position;
			Type = type;
		}
	}
}