﻿namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Effects;
	using RolePlayingGame.Shared.Equipment;
	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public interface ICreature
	{
		string Name { get; }

		IResource Vigour { get; }
		IResource Mana { get; }

		int Temperature { get; }

		int Defence { get; }

		IEnumerable<IAppendage> Appendages { get; }
		int Size { get; }

		List<IEquipment> Equipment { get; }
		List<IEffect> Effects { get; }

		int AdjustTemperature(int amount);

		IAttack Attack(AppendageType appendage);
		IEnumerable<IAttack> Attacks();

		IAppendage? Defend(IAttack attack, IEnumerable<IEffect>? effects = default);
	}
}
