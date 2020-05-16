namespace RolePlayingGame.Shared.Health
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Effects;

	public interface IAppendage
	{
		string Name { get; }
		AppendageType Type { get; }
		AppendageStatus Status { get; }
		int Size { get; }
		int Toughness { get; }

		List<IInjury> Injuries { get; }
		List<IEffect> Effects { get; }

		IAppendage Damage(IAttack attack, IEnumerable<IEffect>? effects = default);
	}
}
