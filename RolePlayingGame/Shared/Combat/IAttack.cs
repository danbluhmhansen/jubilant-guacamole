namespace RolePlayingGame.Shared.Combat
{
	using RolePlayingGame.Shared.Health;

	public interface IAttack
	{
		string Name { get; }
		int Attack { get; }
		IDamage Damage { get; }
		AppendageType Appendages { get; }
	}
}
