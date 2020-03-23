namespace RolePlayingGame.Shared.Combat
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Health;

	public interface IAttack
	{
		string Name { get; }
		int Attack { get; }
		int Damage { get; }
		IEnumerable<AppendageType> Appendages { get; }
	}
}
