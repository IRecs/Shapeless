namespace MapFolder.BlockFolder
{
	public static class Test
	{
		public static BlockData GetTargetBlockData(ContainerData containerData, BlockData currentBlockData) =>
			new BlockData(currentBlockData.Position, BlockType.Wall);
	}
}