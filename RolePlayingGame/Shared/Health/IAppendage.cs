namespace RolePlayingGame.Shared.Health
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;

	public interface IAppendage
	{
		string Name { get; }
		AppendageType Type { get; }
		AppendageStatus Status { get; }
		int Size { get; }
		int Toughness { get; }

		List<IInjury> Injuries { get; }

		IAppendage Damage(IAttack attack);
	}
}
