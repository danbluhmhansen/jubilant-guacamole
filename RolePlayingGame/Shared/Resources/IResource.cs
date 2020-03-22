namespace RolePlayingGame.Shared.Resources
{
	public interface IResource
	{
		int Base { get; }
		int Current { get; }
		int Max { get; }
	}
}
