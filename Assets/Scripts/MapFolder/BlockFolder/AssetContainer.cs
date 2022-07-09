using System.Collections.Generic;
using UnityEngine;

namespace MapFolder.BlockFolder
{
	[CreateAssetMenu(menuName = "new AssetContainer", fileName = "AssetContainer", order = 0)]
	public class AssetContainer : ScriptableObject
	{
		public List<Block> Floors = new List<Block>();
		public List<Block> Walls = new List<Block>();
		public List<Block> Doors = new List<Block>();
	}
}