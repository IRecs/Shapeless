using MapFolder.BlockFolder;
using UnityEngine;
using Zenject;


public class MapInstaller : MonoInstaller
{
	[SerializeField] private AssetContainer _assetContainer;
	[SerializeField] private PositionFinder _positionFinder ;
	
	public override void InstallBindings()
	{
		Container.Bind<AssetContainer>().FromInstance(_assetContainer).AsSingle();
		Container.Bind<PositionFinder>().FromInstance(_positionFinder).AsSingle();
	}
}
