using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MapFolder.BlockFolder
{
	public class BlockObjectPool : MonoBehaviour
	{
		[SerializeField] private int _count;

		private FactoryBlock _factoryBlock;

		private List<Block> _floors = new();
		private List<Block> _walls = new();
		private List<Block> _doors = new();

		private PositionFinder _positionFinder;
		private AssetContainer _assetContainer;

		[Inject]
		public void Construct(AssetContainer assetContainer, PositionFinder positionFinder)
		{
			_positionFinder = positionFinder;
			_assetContainer = assetContainer;
			_factoryBlock = new FactoryBlock(assetContainer);
		}

		private void Start()
		{
			for( int x = 0; x < _count; x++ )
			{
				for( int z = 0; z < _count; z++ )
				{
					var obj = Instantiate(_assetContainer.Floors[0], new Vector3(x * _positionFinder.Step, 0, z * _positionFinder.Step), Quaternion.identity);
					obj.Initialization(new BlockData(new Vector2Int(x, z), BlockType.Floor));
					obj.INeedChange += OnINeedChange;
					_floors.Add(obj);
				}
			}
		}

		public Block GetBlock(ContainerData containerData, BlockData currentBlockData)
		{
			BlockData targetBlockData = Test.GetTargetBlockData(containerData, currentBlockData);

			Block block = GetTargetList(targetBlockData.Type).FirstOrDefault(p => !p.gameObject.activeSelf);

			if(block == null)
			{
				block = _factoryBlock.GetBlock(targetBlockData);
				GetTargetList(targetBlockData.Type).Add(block);
			}

			block.transform.position = _positionFinder.GetPosition(targetBlockData.Position);
			block.gameObject.SetActive(true);
			ClenLists();
			block.INeedChange += OnINeedChange;


			return block;
		}

		public void ClenLists()
		{
			if(_walls.Count + _floors.Count + _doors.Count > 1000)
			{
				ClenList(ref _walls);
				ClenList(ref _floors);
				ClenList(ref _doors);
			}
		}

		private void ClenList(ref List<Block> list)
		{
			for( int i = 0; i <list.Count; i++ )
			{
				if(list[i] == null)
					continue;

				if(list[i].gameObject.activeSelf)
					continue;
				
				Destroy(list[i].gameObject);
				list[i] = null;
				i--;
			}
			
			list = list.Where(p => p != null).ToList();
		}

		private void OnINeedChange(Block obj)
		{
			obj.INeedChange -= OnINeedChange;
			obj.gameObject.SetActive(false);
			GetBlock(new ContainerData(), obj.Data);
		}

		private List<Block> GetTargetList(BlockType blockType)
		{
			return blockType switch
			{
				BlockType.Floor => _floors,
				BlockType.Wall => _walls,
				BlockType.Door => _doors,
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}

}