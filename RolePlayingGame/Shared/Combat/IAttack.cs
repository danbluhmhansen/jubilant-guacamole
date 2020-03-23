namespace RolePlayingGame.Shared.Combat
{
	public interface IAttack
	{
		string Name { get; }
		int Attack { get; }
		int Damage { get; }
	}
}
