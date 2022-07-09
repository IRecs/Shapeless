using UnityEngine;
using Zenject;

namespace MapFolder.BlockFolder
{
	public class PositionFinder : MonoBehaviour
	{
		public float Step { get; private set; } 
		
		[Inject]
		public void Construct(AssetContainer assetContainer) =>
			Step = assetContainer.Floors[0].transform.localScale.x;
		
		public Vector3 GetPosition(Vector2Int position) =>
			new Vector3(position.x * Step,0 ,position.y * Step);
	}
}