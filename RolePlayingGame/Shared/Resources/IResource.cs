namespace RolePlayingGame.Shared.Resources
{
	public interface IResource
	{
		int Base { get; }
		int Current { get; }
		int Max { get; }

		int Adjust(int amount, bool allowOverflow = false);
		IResource Temporary(int amount, bool ignoreCurrent = false);
		IResource Permanent(int amount, bool ignoreCurrent = false);
	}
}
